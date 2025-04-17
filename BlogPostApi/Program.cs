using BlogPostApi.AppContext;
using BlogPostApi.Data;
using BlogPostApi.Data.Services;
using BlogPostApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BlogPostApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Host.UseSerilog((context, services, configuration) =>
			{
				configuration
					.ReadFrom.Configuration(context.Configuration)
					.ReadFrom.Services(services)
					.Enrich.FromLogContext();
			});


			//builder.Logging.AddSerilog(logging);
			// Add services to the container.

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseInMemoryDatabase("AppDbInitializer");
			});

			builder.Services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true; // €?—›⁄«· ò—œ‰ Å«”Œ ŒÊœò«—
			});

			builder.Services.AddTransient<PostService>();
			builder.Services.AddTransient<AppDbInitializer>();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			app.UseMiddleware<ErrorrHandlerMiddelware>();


			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var dbInitializer = services.GetRequiredService<AppDbInitializer>();
				dbInitializer.Seed();
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
