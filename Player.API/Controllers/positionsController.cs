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

	public class positionsController : ControllerBase
	{
		private PositionService _positionService;

		public positionsController()
		{
			_positionService = new PositionService();
		}


		[HttpGet]
		public async Task<IEnumerable<PlayerFunction>> PlayerPositions()
		{
			return await _positionService.GetPositions();
		}

		[HttpGet]
		[Route("acronym")]
		public async Task<ActionResult<PlayerFunction>> PlayerPositions(string acronym)
		{
			var response = await _positionService.GetPositions(acronym);

			if (response == null)
				return BadRequest("Acronym not found");

			return response;
		}

		[HttpPost]
		public async Task<ActionResult<PlayerFunction>> CreatePosition([FromBody] PlayerFunction function)
		{
			var positionBody = new PlayerFunction
			{
				AcronymFunction = function.AcronymFunction,
				NameFunction = function.NameFunction,
			};

			var newPosition = await _positionService.CreatePosition(positionBody);
			return CreatedAtAction(nameof(CreatePosition), new { id = newPosition.Id }, newPosition);
		}

		[HttpPut]
		public async Task<ActionResult> UpdatePosition(int id, [FromBody] PlayerFunction function)
		{
			if (id != function.Id)
				return BadRequest();

			await _positionService.UpdatePosition(function);
			return StatusCode(200);
		}



	};
}
