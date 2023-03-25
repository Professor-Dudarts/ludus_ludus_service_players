using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Player.API.Authentication;
using Player.Domain.Model;

namespace Player.API.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]
	public class AuthenticationController : ControllerBase
	{
		private JwtAuthenticationManager _JwtAuthenticationManager;
		public AuthenticationController(JwtAuthenticationManager JwtAuthenticationManager)
		{
			_JwtAuthenticationManager = JwtAuthenticationManager;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("action")]
		public IActionResult Authenticate(AuthRequest authRequest)
		{
			var token = _JwtAuthenticationManager.Authenticate(authRequest.secret);

			if (token == null)
				return Unauthorized();

			return Ok(token);
		}

	}
}
