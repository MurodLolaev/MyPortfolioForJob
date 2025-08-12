using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio
{
    public class PortfolioDb : DbContext
    {   
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Project> Projects { get; set; }
       

        public PortfolioDb(DbContextOptions<PortfolioDb> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutMe>()
              .Property(a => a.Id)
              .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

           /* modelBuilder.Entity<AboutMe>().HasData(new AboutMe
            {
                Id = 1,
                FullName = "Мурод Джураев",
                Bio = "Разработчик Telegram-ботов и веб-сервисов",
                Skills = "ASP.NET Core, SQL Server",
                Contacts = "murod@example.com",
                Hobbies = "Чтение, спорт",
                PhotoPath = "/images/4.png",
                LinkedInUrl = "https://www.linkedin.com/in/мурод-лолаев-048969345"
            });*/
        }

    }
}
