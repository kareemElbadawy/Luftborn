using Luftborn.Domain.Entities;
using Luftborn.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Luftborn.Core.EFContext
{
	public class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<Players> Players { get; set; }
		public DbSet<Positions> Positions { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
