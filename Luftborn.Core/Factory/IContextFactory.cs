using Luftborn.Core.EFContext;
using Luftborn.Domain.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace Luftborn.Core.Factory
{
	/// <summary>
	/// context factory for ef
	/// </summary>
	public interface IContextFactory
	{
		IDatabaseContext DbContext { get; }
	}
}
