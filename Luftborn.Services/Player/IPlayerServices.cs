using Luftborn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Services.Player
{

	public interface IPlayerServices
	{
		bool Add(Players entity);
		bool AddRange(List<Players> entity);

		bool Update(Players entity);
		IQueryable<Players> Get(params Expression<Func<Players, object>>[] includes);
		IQueryable<Players> Get(Expression<Func<Players, bool>> predicate, params Expression<Func<Players, object>>[] includes);
		IQueryable<Players> Get(Expression<Func<Players, bool>> predicate);

		IList<Players> GetAll();
		IQueryable<Players> GetAll(string include);
		IQueryable<Players> GetAll(string include, string include2);
		IQueryable<Players> GetAll(string include, string include2, string include3, string include4);

		IQueryable<Players> GetAllIQueryable();

		Players GetById(int entityId);
		void GetEditPlayers(Players Players, Players model);
		bool HardDelete(Players model);


	}
}
