using Luftborn.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Luftborn.Domain.Entities
{
	public class Positions : BaseEntity
	{

		public string Name { get; set; }
		public int DisplayOrder
		{
			get; set;
		}
		public virtual ICollection<Players> Players { get; set; }


	}
}
