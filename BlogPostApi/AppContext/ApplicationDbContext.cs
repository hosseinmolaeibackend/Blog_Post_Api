using BlogPostApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogPostApi.AppContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Post> Posts { get; set; }
	}
}
