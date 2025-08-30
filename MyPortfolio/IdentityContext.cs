using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace MyPortfolio
{
    public class IdentityContext  : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) 
        {
            Database.Migrate();
        }

    }
}
