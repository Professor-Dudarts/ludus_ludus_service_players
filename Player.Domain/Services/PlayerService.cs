using Microsoft.EntityFrameworkCore;
using Player.Infraestructure.Contexts;
using Player.Infraestructure.Model;

namespace Player.Domain.Services
{
	public class PlayerService : PlayerBaseService
	{
		public readonly PlayersContext _playersContext;
		public PlayerService()
		{
			_playersContext = new PlayersContext();
		}

		public async Task<IEnumerable<PlayerFunction>> GetPositions()
		{
			return await _playersContext.PlayerFunctions.ToListAsync();
		}

		public async Task<PlayerFunction> GetPositions(string acronym)
		{
			return await _playersContext.PlayerFunctions.Where(x => x.AcronymFunction == acronym).SingleOrDefaultAsync();
		}


	}
}
