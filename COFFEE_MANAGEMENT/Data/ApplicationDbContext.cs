using COFFEE_MANAGEMENT_API.Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace COFFEE_MANAGEMENT_API.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }

    }
}
