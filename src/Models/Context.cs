using Microsoft.EntityFrameworkCore;

namespace dotnet_api.Models
{
    public class AlacenaContext:DbContext {
        public AlacenaContext(DbContextOptions<AlacenaContext> options):base(options){}

        public DbSet<Products> ProductList { get; set; }

        public DbSet<Categories> CategoryList { get; set; }

        public DbSet<CategoriesXProduct> CategoriesXProductList { get; set; }

        public DbSet<Trademarks> TrademarkList { get; set; }

    }
}