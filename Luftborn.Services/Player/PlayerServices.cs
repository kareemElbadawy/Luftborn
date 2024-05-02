using Luftborn.Core.Uow;
using Luftborn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Services.Player
{
	public class PlayersServices : IPlayerServices
	{
		private readonly IUnitOfWork _unitOfWork;

		public PlayersServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public bool Add(Players entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Players>();
					repository.Add(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}

		public IQueryable<Players> Get(Expression<Func<Players, bool>> predicate)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.FindBy(predicate);
		}
		public IQueryable<Players> Get(params Expression<Func<Players, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return (IQueryable<Players>)repository.Get(includes);

		}
		public IQueryable<Players> Get(Expression<Func<Players, bool>> predicate, params Expression<Func<Players, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return (IQueryable<Players>)repository.Get(predicate, includes);

		}

		public IList<Players> GetAll()
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.GetAll().OrderByDescending(x => x.Id).ToList();
		}


		public IQueryable<Players> GetAllIQueryable()
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.GetAll();
		}

		public Players GetById(int entityId)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.Get(entityId);
		}
		public bool Update(Players entityItem)
		{
			bool result = false;

			try
			{
				if (entityItem != null)
				{
					var repository = _unitOfWork.GetRepository<Players>();
					repository.Update(entityItem);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return result;
				//throw;
			}

			return result;
		}
		public IQueryable<Players> GetAll(string include)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.GetAll(include);
		}
		public IQueryable<Players> GetAll(string include, string include2)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.GetAll(include, include2);
		}

		public IQueryable<Players> GetAll(string include, string include2, string include3, string include4)
		{
			var repository = _unitOfWork.GetRepository<Players>();
			return repository.GetAll(include, include2, include3, include4);
		}

		public bool AddRange(List<Players> entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Players>();
					repository.AddRange(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}
		public void GetEditPlayers(Players Modem, Players model)
		{
			if (Modem.Name != model.Name)
			{
				Modem.Name = model.Name;
			}
			if (Modem.ShirtNo != model.ShirtNo)
			{
				Modem.ShirtNo = model.ShirtNo;
			}
			if (Modem.PositionId != model.PositionId)
			{
				Modem.PositionId = model.PositionId;
			}
			if (Modem.Appearances != model.Appearances)
			{
				Modem.Appearances = model.Appearances;
			}
			if (Modem.Goals != model.Goals)
			{
				Modem.Goals = model.Goals;
			}

	}
		public bool HardDelete(Players entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Players>();
					repository.HardDelete(entity);
					_unitOfWork.Commit();
					result = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}

			return result;
		}

	}

}
