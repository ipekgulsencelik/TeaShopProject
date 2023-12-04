using Microsoft.EntityFrameworkCore;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Concrete
{
	public class TeaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;initial catalog=TeaShopProjectDB;integrated security=true;trusted_connection=true;encrypt=false");
        }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}