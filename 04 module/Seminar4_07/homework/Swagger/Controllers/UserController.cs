using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models;

namespace Swagger.Controllers
{
	public class UserController : Controller
	{
		static readonly List<UserInfo> users = new();

		public IActionResult Index() => View();
		[HttpPost("create-user")]
		public IActionResult CreateUser([FromBody] CreateUserRequest req)
		{
			UserInfo user = new() { Id = users.Count == 0 ? 1 : users[^1].Id + 1,
				Email = req.Email, UserName = req.UserName };
			users.Add(user);
			return Ok(user);
		}
		[HttpGet("get-user-by-id")]
		public IActionResult GetUserById([FromQuery] int id)
		{
			List<UserInfo> result = users.Where(x => x.Id == id).ToList();
			if (result.Count == 0)
				return NotFound(new { Message = $"Пользователь с Id = {id} не найден" });
			return Ok(result.First());
		}
		[HttpGet("get-all-users")]
		public IActionResult GetAllUsers() => Ok(users);
	}
}
