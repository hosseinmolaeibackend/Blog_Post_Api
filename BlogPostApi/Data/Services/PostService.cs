using BlogPostApi.AppContext;
using BlogPostApi.Data.Dto;
using BlogPostApi.Data.Entities;
using BlogPostApi.Exceptions;

namespace BlogPostApi.Data.Services
{
	public class PostService(ApplicationDbContext _db)
	{
		Random random = new Random();
		public List<Post> GetAllPosts()
		{
			return _db.Posts.ToList();
		}

		public Post GetPostById(int id)
		{
			return _db.Posts.FirstOrDefault(p => p.Id == id);
		}

		public void CreatePost(CreatePostDto postDto)
		{
			if (string.IsNullOrEmpty(postDto.Title))
				throw new PostException("Title is required.");
			if (string.IsNullOrEmpty(postDto.Content))
				throw new PostException("Content is required.");

			var post = new Post()
			{
				Author = postDto.Author,
				Content = postDto.Content,
				Title = postDto.Title,
				CreateTime = DateTime.Now,
				Id = random.Next(3,10)
			};
			_db.Posts.Add(post);
			_db.SaveChanges();
		}

		public bool DeletePostById(int id)
		{
			var post = _db.Posts.FirstOrDefault(p => p.Id == id);
			if (post != null)
			{
				_db.Posts.Remove(post);
				_db.SaveChanges();
				return true;
			}
			return false;
		}

		public Post UpdatePost(int id, UpdatePostDto postDto)
		{
			var post = _db.Posts.FirstOrDefault(p => p.Id == id);
			if (post != null) 
			{
				post.Author = postDto.Author;
				post.Content = postDto.Content;
				post.Title = postDto.Title;
				_db.Posts.Update(post);
				_db.SaveChanges();
			}
			return post;
		}
	}
}
