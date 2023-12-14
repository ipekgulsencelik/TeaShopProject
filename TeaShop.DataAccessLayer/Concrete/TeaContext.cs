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

        public DbSet<About> Abouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Banner> Banners { get; set; }
    }
}