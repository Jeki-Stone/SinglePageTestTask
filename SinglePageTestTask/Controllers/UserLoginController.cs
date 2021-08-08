using Microsoft.AspNetCore.Mvc;
using SinglePageTestTask.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SinglePageTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoginController : ControllerBase
    {
        private IApplicationService _applicationService;
        public UserLoginController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpGet]
        [Route("Get")]
        public IEnumerable<UserLogin> Get()
        {
            return _applicationService.SelectUsers();
        }

        [HttpGet]
        [Route("GetUsersStories")]
        public IEnumerable<UserHistory> GetUsersStories()
        {
            return _applicationService.UserStories();
        }

        [HttpGet]
        [Route("GetRollingRetention")]
        public IEnumerable<RollingRetention> GetRollingRetention()
        {
            return _applicationService.RollingRetention();
        }

        [HttpPost]
        public bool Post(List<UserLogin> e)
        {
            _applicationService.UpdateUser(e);
            return true;
        }
    }
}
