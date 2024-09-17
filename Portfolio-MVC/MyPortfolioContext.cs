using Microsoft.EntityFrameworkCore;
using Portfolio_MVC.Models;

namespace Portfolio_MVC
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Experience> Experience { get; set; }
    }
}
