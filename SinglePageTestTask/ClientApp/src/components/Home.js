import { data } from 'jquery';
import React, { Component } from 'react';
import {
    BarChart,
    Bar,
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    Legend,
    LabelList,
    ReferenceLine
} from "recharts";
import DatePicker from "react-datepicker";
import './Home.css';
import "react-datepicker/dist/react-datepicker.css";
import { registerLocale, setDefaultLocale } from "react-datepicker";
import ru from 'date-fns/locale/ru';
registerLocale('ru', ru);

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { userLogins: [], userLoginOlds: [], userStories: [], rollingRetention: [], calculateView: true, loading: true };
    }

    componentDidMount() {
        this.populateUserLoginData();
    }

    renderUserLoginsTable = (userLogins) => {
        return (
            <table aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>UserId</th>
                        <th>Date Registration</th>
                        <th>Date Last Activity</th>
                    </tr>
                </thead>
                <tbody>
                    {userLogins.map(userLogin =>
                        <tr key={userLogin.userId}>
                            <td>{userLogin.userId}</td>
                            <td><DatePicker selected={Date.parse(userLogin.dateRegistration)} onChange={e => this.changeValue(userLogin.userId, e, "dtR")} dateFormat="dd.MM.yyyy" locale={ru} /></td>
                            <td><DatePicker selected={Date.parse(userLogin.dateLastActivity)} onChange={e => this.changeValue(userLogin.userId, e, "dtL")} dateFormat="dd.MM.yyyy" locale={ru} /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderUserLoginsTable(this.state.userLogins);
        let rollingRetention = this.state.calculateView
            ? <p></p>
            : this.rollingRetentionSeven(this.state.rollingRetention);
        let charts = this.state.calculateView
            ? <p></p>
            : this.charts(this.state.userStories);

        return (
            <div className="panel">
                <div className="container">
                    <h2 className="tableLabel" >Full stack developer</h2>
                    {contents}
                    <div className="buttans">
                        <button className="btn" onClick={this.saveValue}>Save</button>
                        <button className="btn" onClick={this.calculate}>Calculate</button>
                    </div>
                    {rollingRetention}
                    {charts}
                </div>
            </div>
        );
    }

    changeValue = (id, value, dt) => {
        console.log(value, dt);
        let col = this.state.userLogins;
        if (dt === "dtR") {
            col.find(el => { return el.userId === id; }).dateRegistration = value;
        }
        else if (dt === "dtL") {
            col.find(el => { return el.userId === id; }).dateLastActivity = value;
        }
        this.setState({ userLogins: col });
    }

    saveValue = () => {
        let difference = [];
        for (let i = 0; i < this.state.userLogins.length; i++) {
            if (JSON.stringify(this.state.userLogins[i]) !== JSON.stringify(this.state.userLoginOlds[i])) {
                difference.push(this.state.userLogins[i])
            }
        };
        if (difference.length !== 0) {
            let f = fetch('UserLogin', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(difference),
            })
                .then(response => { response.json() })
        }
    }

    calculate = async () => {
        const response = await fetch('UserLogin/GetUsersStories');
        const data = (await response.json()).sort(function (a, b) {
            if (a.userId > b.userId) {
                return 1;
            }
            if (a.userId < b.userId) {
                return -1;
            }
            return 0;
        });
        const bar = data.map(el => { return { name: "User ID " + el.userId, days: el.days } });
        this.setState({ userStories: bar })
        const response1 = await fetch('UserLogin/GetRollingRetention');
        const data1 = await response1.json();
        const line = data1.map(el => { return { day: "Day " + el.dayOfWeek, value: el.value, l: 100 } });
        this.setState({ calculateView: false, rollingRetention: line })
    }

    rollingRetentionSeven = (line) => {
        return (
            <div className="cart">
                <h2 className="tableLabel" >Rolling Retention 7 day</h2>
                <LineChart
                width={770}
                height={400}
                data={line}
                margin={{
                    top: 5,
                    right: 30,
                    left: 20,
                    bottom: 5
                }}
                >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="day" />
                <YAxis />
                <Line dataKey="value" fill="#5D6D97" stroke="#5D6D97" />
                <Line dataKey="l" fill="#0000" stroke="#0000"/>
                </LineChart>
            </div>
        );
    }

    charts = (bar) => {
        return (
            <div className="cart">
                <BarChart
                width={770}
                height={400}
                data={bar}
                margin={{
                    top: 5,
                    right: 30,
                    left: 20,
                    bottom: 5
                }}
                >
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="name" />
                <YAxis />
                <Tooltip />
                <Legend />
                <Bar dataKey="days" fill="#5D6D97" />
                </BarChart>
            </div>
        );
    }

    async populateUserLoginData() {
        const response = await fetch('UserLogin/Get');
        const data = (await response.json()).sort(function (a, b) {
            if (a.userId > b.userId) {
                return 1;
            }
            if (a.userId < b.userId) {
                return -1;
            }
            return 0;
        });
        const data1 = data.map(el => { let el1 = {}; Object.assign(el1, el); return el1; });
        this.setState({
            userLogins: data, userLoginOlds: data1, loading: false
        });
    }
}
