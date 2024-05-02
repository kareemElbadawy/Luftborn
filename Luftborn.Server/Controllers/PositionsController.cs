using AutoMapper;
using Luftborn.Domain.Entities;
using Luftborn.Server.ViewModels;
using Luftborn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PositionsController : Controller
	{
		private readonly IPositionsServices PositionsManager;
		private readonly IMapper Mapper;
		public PositionsController(IPositionsServices PositionsManger, IMapper Mapper)
		{
			this.PositionsManager = PositionsManger;
			this.Mapper = Mapper;
		}
		[HttpGet("GetAllPositions")]
		public IActionResult Get()
		{
			try
			{
				var requests = PositionsManager.Get();
				return Ok(requests.ToList());
			}
			catch (Exception ex)
			{
				return Ok(new { Positions = false, error = ex.Message });
			}
		}
	}
}
