using Microsoft.EntityFrameworkCore;
using sistema_relatorios.models;

namespace sistema_relatorios.database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<TaxRuleModel> TaxRule { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }
    }
}
