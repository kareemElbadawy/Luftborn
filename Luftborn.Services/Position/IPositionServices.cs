using Luftborn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Luftborn.Services
{
	public interface IPositionsServices
	{
		bool Add(Positions entity);
		bool AddRange(List<Positions> entity);
		void GetEditPosition(Positions Position, Positions model);

		bool Update(Positions entity);
		IQueryable<Positions> Get(params Expression<Func<Positions, object>>[] includes);
		IQueryable<Positions> Get(Expression<Func<Positions, bool>> predicate, params Expression<Func<Positions, object>>[] includes);
		IQueryable<Positions> Get(Expression<Func<Positions, bool>> predicate);

		IList<Positions> GetAll();
		IQueryable<Positions> GetAll(string include);
		IQueryable<Positions> GetAll(string include, string include2);
		IQueryable<Positions> GetAll(string include, string include2, string include3, string include4);

		IQueryable<Positions> GetAllIQueryable();

		Positions GetById(int entityId);
		bool HardDelete(Positions model);


	}

}
