using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Player.Domain.Services;
using Player.Infraestructure.Contexts;
using Player.Infraestructure.Model;

namespace Player.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]

	public class PlayerController : ControllerBase
	{
		private PlayerService _playerService;

		public PlayerController()
		{
			_playerService = new PlayerService();
		}


		[HttpGet]
		[Route("Positions")]
		public async Task<IEnumerable<PlayerFunction>> PlayerPositions()
		{
			return await _playerService.GetPositions();
		}

		[HttpGet]
		[Route("Positions/acronym")]
		public async Task<ActionResult<PlayerFunction>> GetCoins(string acronym)
		{
			var response = await _playerService.GetPositions(acronym);

			if (response == null)
				return BadRequest();

			return response;
		}


	};
}
