using Microsoft.EntityFrameworkCore;

namespace PersonalWebSite.Models
{
	public class Context : DbContext
	{
		public DbSet<Admin> Admins { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Image> Images { get; set; }

		public Context(DbContextOptions<Context> options):base(options) 
		{

		}

	}
}
