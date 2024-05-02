﻿using Luftborn.Core.EFContext;
using Luftborn.Core.Repositories.Interface;
using Luftborn.Domain.Base;

namespace Luftborn.Core.Uow
{
	public interface IUnitOfWork
	{
		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
		int Commit();
		/// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
		Task<int> CommitAsync();
		/// <returns>Repository</returns>
		IGenericRepository<TEntity> GetRepository<TEntity>()
			where TEntity : BaseEntity;
		IDatabaseContext Context { get; }
	}
}
