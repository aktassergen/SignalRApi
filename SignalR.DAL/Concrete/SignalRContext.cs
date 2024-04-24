using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DAL.Concrete
{
    public class SignalRContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contant> Contants { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SosialMedia> SosialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<MenuTable> MenuTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SERGEN\\SQLEXPRESS;Initial Catalog=SignalR;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<About>().HasKey(a => a.AboutId);
            modelBuilder.Entity<Booking>().HasKey(a => a.BookingId);
            modelBuilder.Entity<Category>().HasKey(a => a.CategoryId);
            modelBuilder.Entity<Contant>().HasKey(a => a.ContantId);
            modelBuilder.Entity<Discount>().HasKey(a => a.DiscountId);
            modelBuilder.Entity<Feature>().HasKey(a => a.FeatureId);
            modelBuilder.Entity<Product>().HasKey(a => a.ProductId);
            modelBuilder.Entity<SosialMedia>().HasKey(a => a.SocialMediaId);
            modelBuilder.Entity<Testimonial>().HasKey(a => a.TestimonialId);
        }


    }
}
