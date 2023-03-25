using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Player.Domain.Services;

namespace Player.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]

	public class PlayerController : ControllerBase
	{
		private PlayerBaseService _PlayerService;

		public PlayerController()
		{
			_PlayerService = new PlayerService();
		}

		[HttpGet]
		[Route("Teste")]
		public string Teste()
		{
			return "Testado";
		}

	};
}
