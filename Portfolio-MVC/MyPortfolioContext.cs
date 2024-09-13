using Microsoft.EntityFrameworkCore;
using Portfolio_MVC.Models;

namespace Portfolio_MVC
{
    public class MyPortfolioContext : DbContext
    {
        public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options)
            : base(options) { }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
