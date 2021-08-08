using System.Collections.Generic;

namespace SinglePageTestTask.Data
{
    public interface IApplicationService
    {
        List<UserLogin> SelectUsers();
        void UpdateUser(List<UserLogin> user);
        List<UserHistory> UserStories();
        List<RollingRetention> RollingRetention();
    }
}