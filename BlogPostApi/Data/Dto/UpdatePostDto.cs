using System.ComponentModel.DataAnnotations;

namespace BlogPostApi.Data.Dto
{
	public class UpdatePostDto
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }
		[Required]
		public string Content { get; set; }

		public string Author { get; set; }
	}
}
