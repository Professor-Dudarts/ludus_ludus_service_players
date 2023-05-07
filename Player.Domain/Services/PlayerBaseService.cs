
namespace Player.Domain.Services
{
	public abstract class PlayerBaseService
	{
		public DateTime BrasiliaTime() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

	}
}
