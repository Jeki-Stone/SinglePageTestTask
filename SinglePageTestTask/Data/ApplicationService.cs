using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageTestTask.Data
{
    public class ApplicationService : IApplicationService
    {
        private ApplicationDbContext _dbContext;

        public ApplicationService(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        /// <summary>
        /// Вызов всех данных
        /// </summary>
        /// <returns></returns>
        public List<UserLogin> SelectUsers()
        {
            var data = _dbContext.Users.ToList<UserLogin>();
            return data;
            
        }

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(List<UserLogin> users)
        {
            foreach (var user in users)
            {
                var _user = _dbContext.Find<UserLogin>(user.UserId);
                _user.DateRegistration = user.DateRegistration;
                _user.DateLastActivity = user.DateLastActivity;
                _dbContext.Update<UserLogin>(_user);
            }
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Считает срок жизни пользователей
        /// </summary>
        /// <returns></returns>
        public List<UserHistory> UserStories()
        {
            List<UserHistory> userHistorys = new List<UserHistory>();
            foreach (var user in _dbContext.Users.ToList<UserLogin>())
            {
                int date = (int)Math.Abs((user.DateLastActivity - user.DateRegistration).TotalDays);
                userHistorys.Add(new UserHistory() { UserId = user.UserId, Days = date });
            }
            return userHistorys;
        }

        /// <summary>
        /// Считает Rolling Retention 7 дней назад заканчивая сегодняшним
        /// </summary>
        /// <returns></returns>
        public List<RollingRetention> RollingRetention()
        {
            List<RollingRetention> rolReten7 = new List<RollingRetention>();

            for (int i = 1; i <= 7; i++)
            {
                decimal usersReturned = 0;
                decimal usersInstalled = 0;
                DateTime date = DateTime.Now.AddDays(-7 + i);
                foreach (var user in _dbContext.Users.ToList<UserLogin>())
                {
                    if (user.DateRegistration <= date)
                    {
                        usersInstalled++;
                        if (user.DateLastActivity >= date)
                            usersReturned++;
                    }
                }
                if (usersInstalled != 0 || usersInstalled != 0)
                {
                    decimal value = usersReturned / usersInstalled * 100;
                    rolReten7.Add(new RollingRetention() { DayOfWeek = i, Value = Math.Round(value, 2) });
                }
            }
            return rolReten7;
        }
    }
}
