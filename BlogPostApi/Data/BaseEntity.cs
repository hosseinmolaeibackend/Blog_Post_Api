namespace BlogPostApi.Data
{
	public class BaseEntity<T>
	{
		public T Id { get; set; }
		public DateTime CreateTime { get; set; }
	}
}
