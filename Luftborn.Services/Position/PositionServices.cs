using Luftborn.Core.Uow;
using Microsoft.EntityFrameworkCore;
using Luftborn.Core.Uow;
using Luftborn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Luftborn.Services
{
	public class PositionsServices : IPositionsServices
	{
		private readonly IUnitOfWork _unitOfWork;

		public PositionsServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public bool Add(Positions entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Positions>();
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

		public IQueryable<Positions> Get(Expression<Func<Positions, bool>> predicate)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.FindBy(predicate);
		}
		public IQueryable<Positions> Get(params Expression<Func<Positions, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return (IQueryable<Positions>)repository.Get(includes);
		}
		public IQueryable<Positions> Get(Expression<Func<Positions, bool>> predicate, params Expression<Func<Positions, object>>[] includes)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return (IQueryable<Positions>)repository.Get(predicate, includes);
		}

		public IList<Positions> GetAll()
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.GetAll().OrderByDescending(x => x.Id).ToList();
		}


		public IQueryable<Positions> GetAllIQueryable()
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.GetAll();
		}

		public Positions GetById(int entityId)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.Get(entityId);
		}
		public bool Update(Positions entityItem)
		{
			bool result = false;

			try
			{
				if (entityItem != null)
				{
					var repository = _unitOfWork.GetRepository<Positions>();
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
		public IQueryable<Positions> GetAll(string include)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.GetAll(include);
		}
		public IQueryable<Positions> GetAll(string include, string include2)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.GetAll(include, include2);
		}

		public IQueryable<Positions> GetAll(string include, string include2, string include3, string include4)
		{
			var repository = _unitOfWork.GetRepository<Positions>();
			return repository.GetAll(include, include2, include3, include4);
		}

		public bool AddRange(List<Positions> entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Positions>();
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
		public void GetEditPosition(Positions Position, Positions model)
		{
			if (Position.Name != model.Name)
			{
				Position.Name = model.Name;
			}
			if (Position.DisplayOrder != model.DisplayOrder)
			{
				Position.DisplayOrder = model.DisplayOrder;
			}

		}
		public bool HardDelete(Positions entity)
		{
			bool result = false;

			try
			{
				if (entity != null)
				{
					//bissnus

					var repository = _unitOfWork.GetRepository<Positions>();
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
