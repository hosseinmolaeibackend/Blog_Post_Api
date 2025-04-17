using BlogPostApi.AppContext;
using BlogPostApi.Data.Dto;
using BlogPostApi.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Blog_Test
{
	public class PostServiceTest
	{
		private static DbContextOptions<ApplicationDbContext> _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
			.UseInMemoryDatabase(databaseName: "BlogTestDb")
			.Options;
		ApplicationDbContext context;
		PostService _postService;

		[OneTimeSetUp]
		public void Setup()
		{
			context = new ApplicationDbContext(_contextOptions);
			context.Database.EnsureCreated();
			SeedDatabase();
			_postService = new PostService(context);
		}



		[Test, Order(1)]
		public void GetAllPosts_Test()
		{
			var posts = _postService.GetAllPosts();
			Assert.IsNotNull(posts);
			Assert.AreEqual(5, posts.Count);
		}

		[Test, Order(2)]
		public void GetPostByIdWithOutErrorr_Test()
		{
			var post = _postService.GetPostById(1);
			Assert.IsNotNull(post);
			Assert.AreEqual("Test Title 1", post.Title);
		}

		[Test, Order(3)]
		public void GetPostByIdWithErrorr_Test()
		{
			var post = _postService.GetPostById(10);
			Assert.IsNull(post);
		}

		[Test, Order(4)]
		public void CreatePostWithOutError_Test()
		{
			var post = new CreatePostDto
			{
				Title = "Test Title 6",
				Content = "Test Content 6",
				Author = "Test Author 6",
			};
			_postService.CreatePost(post);
			var newpost = _postService.GetPostById(6);
			Assert.IsNotNull(newpost);
			Assert.That(newpost.Title, Is.EqualTo("Test Title 6"));
		}

		[Test, Order(5)]
		public void CreatePostWithError_Test()
		{
			var post = new CreatePostDto
			{
				Title = "",
				Content = "Test Content 7",
				Author = "Test Author 7",
			};
			var ex = Assert.Throws<ArgumentException>(() => _postService.CreatePost(post));
			Assert.That(ex.Message, Is.EqualTo("Title is required."));
		}

		[Test, Order(6)]
		public void DeletedPostById_Test()
		{
			var result = _postService.DeletePostById(1);
			var post = _postService.GetPostById(1);
			Assert.IsNull(post);
			Assert.That(result, Is.EqualTo(true));
			Assert.AreEqual(4, context.Posts.Count());
		}



		[OneTimeTearDown]
		public void Cleanup()
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}

		private void SeedDatabase()
		{
			context.Posts.AddRange(new List<BlogPostApi.Data.Entities.Post>
			{
				new BlogPostApi.Data.Entities.Post
				{
					Id = 1,
					Title = "Test Title 1",
					Content = "Test Content 1",
					Author = "Test Author 1",
					CreateTime = DateTime.Now
				},
				new BlogPostApi.Data.Entities.Post
				{
					Id = 2,
					Title = "Test Title 2",
					Content = "Test Content 2",
					Author = "Test Author 2",
					CreateTime = DateTime.Now
				},
				new BlogPostApi.Data.Entities.Post
				{
					Id = 3,
					Title = "Test Title 3",
					Content = "Test Content 3",
					Author = "Test Author 3",
					CreateTime = DateTime.Now
				},
				new BlogPostApi.Data.Entities.Post
				{
					Id = 4,
					Title = "Test Title 4",
					Content = "Test Content 4",
					Author = "Test Author 4",
					CreateTime = DateTime.Now
				},
				new BlogPostApi.Data.Entities.Post
				{
					Id = 5,
					Title = "Test Title 5",
					Content = "Test Content 5",
					Author = "Test Author 5",
					CreateTime = DateTime.Now
				}
			});
			context.SaveChanges();
		}

	}
}