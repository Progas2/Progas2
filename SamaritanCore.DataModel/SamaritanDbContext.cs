using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamaritanCore.DataModel.Models;

namespace SamaritanCore.DataModel
{
    public class SamaritanDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public SamaritanDbContext(DbContextOptions<SamaritanDbContext> options) : base(options)
        {
        }

        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
