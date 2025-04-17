using System.ComponentModel.DataAnnotations;

namespace BlogPostApi.Data.Dto
{
	public class CreatePostDto
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }

		public string Author { get; set; }
	}
}
