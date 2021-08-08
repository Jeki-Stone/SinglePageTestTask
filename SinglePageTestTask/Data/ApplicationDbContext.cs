using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SinglePageTestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserLogin> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin[]
                {
                new UserLogin { UserId=1, DateRegistration=DateTime.Now, DateLastActivity=DateTime.Now},
                new UserLogin { UserId=2, DateRegistration=DateTime.Now, DateLastActivity=DateTime.Now},
                new UserLogin { UserId=3, DateRegistration=DateTime.Now, DateLastActivity=DateTime.Now},
                new UserLogin { UserId=4, DateRegistration=DateTime.Now, DateLastActivity=DateTime.Now},
                new UserLogin { UserId=5, DateRegistration=DateTime.Now, DateLastActivity=DateTime.Now},
                });
        }
    }
}
