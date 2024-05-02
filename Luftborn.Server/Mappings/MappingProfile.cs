using AutoMapper;
using static Azure.Core.HttpHeader;
using System.Data;
using System.Security.Policy;
using Luftborn.Server.ViewModels;
using Luftborn.Domain.Entities;

namespace Luftborn.Server.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			CreateMap<PlayersVM, Players>();
			CreateMap<Players, PlayersVM>();
			CreateMap<PositionsVM, Positions>();
			CreateMap<Positions, PositionsVM>();

		}
	}

}
