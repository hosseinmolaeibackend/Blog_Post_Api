using BlogPostApi.Data.Dto;
using BlogPostApi.Data.Entities;
using BlogPostApi.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController(PostService service) : ControllerBase
	{
		[HttpGet("get-all-post")]
		public IActionResult GetAllPosts()
		{
			var _response = service.GetAllPosts();
			return Ok(_response);
		}

		[HttpGet("get-post/{id}")]
		public IActionResult GetPost(int id)
		{
			var response = service.GetPostById(id);
			if (response == null)
			{
				return NotFound();
			}
			return Ok(response);
		}

		[HttpPost("add-post")]
		public IActionResult CreatePost([FromBody] CreatePostDto post)// return status code 201
		{
			//if (!ModelState.IsValid)
			//{
			//	return BadRequest(post);
			//}
			service.CreatePost(post);

			var postid = service.GetAllPosts().LastOrDefault().Id;

			//return Created();
			return CreatedAtAction(nameof(GetPost), new
			{
				id = postid
			}, new Post());
		}

		[HttpDelete("delete-post/{id}")]
		public IActionResult DeletePost(int id)
		{
			if (service.DeletePostById(id))
				return Ok();
			return NoContent();
		}

		[HttpPut("update-post/{id}")]
		public IActionResult UpdatePost(int id, [FromBody] UpdatePostDto post)
		{
			if (!ModelState.IsValid) return BadRequest();
			var update = service.UpdatePost(id, post);
			return update != null ? Ok(update) : NotFound();
		}
	}
}
