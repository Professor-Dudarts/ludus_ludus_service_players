using Microsoft.EntityFrameworkCore;
using Player.Domain.Model.Player;
using Player.Infraestructure.Contexts;
using Player.Infraestructure.Model;

namespace Player.Domain.Services
{
	public class PlayerService : BaseService
	{
		public readonly PlayersContext _playersContext;
		public PlayerService()
		{
			_playersContext = new PlayersContext();
		}

		public async Task<List<PlayerInformation>> GetPlayers()
		{
			var response = await _playersContext.Players.ToListAsync();

			var listInformation = new List<PlayerInformation>();

			response.ForEach(player =>
			{
				var function = _playersContext.PlayerFunctions.Find(player.FkFunctionId);

				listInformation.Add(new PlayerInformation
				{
					Id = player.Id,
					Email = player.Email,
					Age= player.Age,
					Cpf= player.Cpf,
					DateOfBirth= player.DateOfBirth.ToShortDateString(),
					FullName = player.FullName,
					Function = function.NameFunction,
					AcronymFunction = function.AcronymFunction,
					Nationality = player.Nationality,
					Nickname= player.Nickname,
					PhoneNumber= player.PhoneNumber,
					RepresentativeName= player.RepresentativeName ?? "N/A",
					RepresentativePhoneNumber = player.RepresentativePhoneNumber ?? "N/A",
					ShirtNumber= player.ShirtNumber,
				});
			});

			return listInformation;
		}

	}
}
