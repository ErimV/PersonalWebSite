using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PersonalWebSite.Models
{
	public class Context : DbContext
	{
		public Context()
		{

		}
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Server=DESKTOP-9BEN4HD; Initial Catalog=PersonalWebSiteDB; User Id=erimv; Password=123456; TrustServerCertificate=True");
            }
        }
    }
}
