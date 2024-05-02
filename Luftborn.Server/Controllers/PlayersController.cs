using AutoMapper;
using Luftborn.Domain.Entities;
using Luftborn.Server.ViewModels;
using Luftborn.Services.Player;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Server.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : Controller
	{
		private readonly IPlayerServices PlayersManager;
		private readonly IMapper Mapper;
		public PlayersController(IPlayerServices PlayersManger, IMapper Mapper)
		{
			this.PlayersManager = PlayersManger;
			this.Mapper = Mapper;
		}
		[HttpGet("GetAllPlayers")]
		public IActionResult Get([FromHeader] PaginationViewModel model)
		{
			try
			{


				model.pagenumber = model.pagenumber == null || model.pagenumber == 0 ? 1 : model.pagenumber;
				var requests = PlayersManager.Get(x => x.Positions);

				if (!string.IsNullOrEmpty(model.searchvalue))
				{
					model.searchvalue = model.searchvalue.ToLower().Trim();
					requests = requests.Where(p => p.Id.ToString().Contains(model.searchvalue)
					|| (p.Id != null && p.Id.ToString().ToLower().Contains(model.searchvalue))
					|| (p.Name != null && p.Name.ToLower().Contains(model.searchvalue))
					|| (p.CreationDate != null && p.CreationDate.ToString().ToLower().Contains(model.searchvalue))
					|| (p.ModificationDate != null && p.ModificationDate.ToString().ToLower().Contains(model.searchvalue))
					);
				}
				int TotalRecords = requests.Count();
				if (TotalRecords == 0)
					TotalRecords = 1;
				model.pagesize = model.pagesize == null || model.pagesize == 0 ? TotalRecords : model.pagesize;
				int TotalPages = TotalRecords / model.pagesize.Value;
				double ieee = Math.IEEERemainder(TotalRecords, model.pagesize.Value);
				if (ieee >= 1)
				{
					TotalPages++;
				}
				if (TotalPages == 0 && TotalRecords > 1)
				{
					TotalPages = 1;
				}
				requests = requests.OrderBy(x => x.Id);
				List<Players> _requests = requests.ToList().Skip((model.pagenumber.Value - 1) * model.pagesize.Value).Take(model.pagesize.Value).ToList();
				var allrequests = Mapper.Map<List<Players>, List<PlayersVM>>(_requests);
				allrequests = allrequests.OrderBy(p => p.Id).ToList();
				return Ok(allrequests);
			}
			catch (Exception ex)
			{
				return Ok(new { Players = false, error = ex.Message });
			}
		}
		[HttpGet("GetPlayersById/{id}")]
		public IActionResult GetPlayersById(int id)
		{
			try
			{
				Players Players = PlayersManager.GetById(id);
				if (Players != null)
				{
					var item = Mapper.Map<Players, PlayersVM>(Players);
					return Ok(item);
				}
				return Ok(new { Players = false, error = "Invalid Id" });
			}
			catch (Exception ex)
			{
				return Ok(new { Players = false, error = ex.Message });
			}
		}
		[HttpPost("AddPlayers")]
		public IActionResult Post([FromBody] PlayersVM model)
		{
			try
			{
				
				Players Players = Mapper.Map<PlayersVM, Players>(model);
				Players.CreationDate = DateTime.Now;
				PlayersManager.Add(Players);
				return Ok(new { Players = true, data = Players });
			}
			catch (Exception ex)
			{
				return Ok(new { Players = false, error = ex.Message });
			}
		}
		[HttpPut("UpdatePlayers")]

		public IActionResult UpdatePlayers([FromBody] PlayersVM model)
		{
			try
			{
				var Players = PlayersManager.GetById(model.Id);
				if (Players != null)
				{

					Players sermodel = Mapper.Map<PlayersVM, Players>(model);
				
					PlayersManager.GetEditPlayers(Players, sermodel);
					Players.ModificationDate = DateTime.Now;
					PlayersManager.Update(Players);
					model = Mapper.Map<Players, PlayersVM>(Players);
					return Ok(new { Players = true, data = model });
				}
				else
				{
					return Ok(new { Players = false, error = "Invalid Data" });
				}

			}
			catch (Exception ex)
			{
				return Ok(new { Players = false, error = ex.Message });
			}

		}
		[HttpGet("RemovePlayers/{id}")]
		public IActionResult RemovePlayers(int id)
		{
			try
			{
				Players Players = PlayersManager.GetById(id);
				if (Players != null)
				{
					
					Players.IsDeleted = true;
					Players.ModificationDate = null;
					PlayersManager.Update(Players);
					return Ok(new { Players = true });
				}
				else
				{
					return Ok(new { Players = false, error = "Invalid Data" });
				}
			}
			catch (Exception ex)
			{
				return Ok(new { Players = false, error = ex.Message });
			}
		}
	}
}
