using Microsoft.EntityFrameworkCore;
using sistema_relatorios.models;

namespace sistema_relatorios.database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        //public DbSet<ProductModel> TaxRule { get; set; }
        //public DbSet<Produto> Produtos { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        
        }

    }
}
