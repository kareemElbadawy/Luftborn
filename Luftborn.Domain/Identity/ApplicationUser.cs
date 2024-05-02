using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Domain.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public int CorporationId { get; set; }

	}
}
