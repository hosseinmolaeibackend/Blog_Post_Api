using System.ComponentModel.DataAnnotations;

namespace BlogPostApi.Exceptions
{
	public class ErrorrHandlerMiddelware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ErrorrHandlerMiddelware> _logger;
		public ErrorrHandlerMiddelware(RequestDelegate next, ILogger<ErrorrHandlerMiddelware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (PostException ex)
			{
				_logger.LogWarning(ex, "Validation errorr.");
				context.Response.StatusCode = 400;
				await context.Response.WriteAsJsonAsync(new { error = ex.Message });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Unexpected error.");
				context.Response.StatusCode = 500;
				await context.Response.WriteAsJsonAsync(new { error = "Internal server error" });
			}
		}
	}
}
