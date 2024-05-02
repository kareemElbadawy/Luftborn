using Luftborn.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Luftborn.Domain.Entities
{
	public class Players :BaseEntity
	{
		
		public string Name { get; set; }
		public int ShirtNo { get; set; }
		public int PositionId { get; set; }
		public int Appearances { get; set; }
		public int Goals { get; set; }
		[ForeignKey("PositionId")]
		public virtual Positions Positions { get; set; }
		[NotMapped]
		public string PositionName {
			get
			{
				if (Positions != null)
				{
					return Positions.Name;
				}
				return null;
			}			
		}
	}
}
