using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Player.Domain.Model.Player;
using Player.Domain.Services;
using Player.Infraestructure.Contexts;
using Player.Infraestructure.Model;
using static Player.Domain.Services.PlayerService;

namespace Player.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]

	public class playersController : ControllerBase
	{
		private PlayerService _playerService;

		public playersController()
		{
			_playerService = new PlayerService();
		}


		[HttpGet]
		public async Task<List<PlayerInformation>> GetPlayers()
		{
			return await _playerService.GetPlayers();
		}

	};
}
