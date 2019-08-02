using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Models
{
	public class OrderUserContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public OrderUserContext(DbContextOptions<OrderUserContext> options):base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Order>().HasKey(table => new {
				table.UserId,
				table.Odate
			});
		}
	}
}
