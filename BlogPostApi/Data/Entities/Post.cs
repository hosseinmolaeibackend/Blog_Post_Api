using System.ComponentModel.DataAnnotations;

namespace BlogPostApi.Data.Entities
{
	public class Post : BaseEntity<int>
	{
		[Required]
		[MaxLength(100)]
		public string Title { get; set; } = default!;
		[Required]
		public string Content { get; set; } = default!;

		public string Author { get; set; }
	}
}
