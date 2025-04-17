using BlogPostApi.AppContext;
using BlogPostApi.Data.Entities;

namespace BlogPostApi.Data
{
	public class AppDbInitializer
	{
		private readonly ApplicationDbContext _context;
		public AppDbInitializer(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Seed()
		{
			if (!_context.Posts.Any())
			{
				_context.Posts.AddRange(new Post()
				{
					Id = 1,
					Title = "Title 1st",
					Content = "content 1st",
					Author = "Author 1st",
					CreateTime = DateTime.Now,
				}, new Post()
				{
					Id = 2,
					Title = "Title 2nd",
					Content = "content 2nd",
					Author = "Author 2nd",
					CreateTime = DateTime.Now,
				}
				);
				_context.SaveChanges();
			}
		}
	}
}
