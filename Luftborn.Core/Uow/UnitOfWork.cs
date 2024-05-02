﻿using System.Threading.Tasks;
using Luftborn.Core.EFContext;
using Luftborn.Core.Factory;
using Luftborn.Core.Repositories.Base;
using Luftborn.Core.Repositories.Interface;
using Luftborn.Domain.Base;

namespace Luftborn.Core.Uow
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private IDatabaseContext dbContext;

		private Dictionary<Type, object> repos;
		public IDatabaseContext Context { get; }
		public UnitOfWork(IDatabaseContext databaseContext)
		{
			dbContext = databaseContext;
		}

		public IGenericRepository<TEntity> GetRepository<TEntity>()
			where TEntity : BaseEntity
		{
			if (repos == null)
			{
				repos = new Dictionary<Type, object>();
			}

			var type = typeof(TEntity);
			if (!repos.ContainsKey(type))
			{
				repos[type] = new GenericRepository<TEntity>(dbContext);
			}

			return (IGenericRepository<TEntity>)repos[type];
		}

		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
		public int Commit()
		{
			return dbContext.SaveChanges();
		}
		public async Task<int> CommitAsync()
		{
			return await dbContext.SaveChangesAsync(CancellationToken.None);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(obj: this);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (dbContext != null)
				{
					dbContext.Dispose();
					dbContext = null;
				}
			}
		}
	}

}
