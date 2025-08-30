using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio
{
    public class PortfolioDb : DbContext
    {   
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public PortfolioDb(DbContextOptions<PortfolioDb> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutMe>()
              .Property(a => a.Id)
              .ValueGeneratedOnAdd();
            modelBuilder.Entity<Contact>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                Phone = "+992985630599",
                Email = "murod99_99@bk.ru",
                Address = "A.Сино хонаи 4 ошёна 1",
                City = "Душанбе" ,
                Whatsapp = "+992985630599",
                Telegram = "+992985630599",
                Linkedin = "https://www.linkedin.com/in/мурод-лолаев-048969345",
                GitHub = "https://github.com/NikClouse?tab=repositories"
            });

           
        }


    }
}
