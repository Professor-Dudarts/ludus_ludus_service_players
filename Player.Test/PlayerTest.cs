using Player.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Player.Domain.Model;
using System.Net;

namespace Player.Test
{
	[TestClass]
	public class PlayerTest
	{
		private PlayerService _playerService = new PlayerService();

		[TestMethod]
		public void TestGetPositionList()
		{
			BaseResponse response = new BaseResponse();
			try
			{
				response.Data = _playerService.GetPositions().Result;
				response.Message = "Task Finished";
				response.HttpStatusCode = HttpStatusCode.OK;
			}
			catch(Exception exception)
			{
				response.Data = null;
				response.Message = exception.Message;
				response.HttpStatusCode = HttpStatusCode.InternalServerError;
			}
		}


		[TestMethod]
		public void TestGetPosition()
		{
			BaseResponse response = new BaseResponse();
			try
			{
				response.Data = _playerService.GetPositions("e").Result;
				response.Message = "Task Finished";
				response.HttpStatusCode = HttpStatusCode.OK;
			}
			catch (Exception exception)
			{
				response.Data = null;
				response.Message = exception.Message;
				response.HttpStatusCode = HttpStatusCode.InternalServerError;
			}
		}

	}
}