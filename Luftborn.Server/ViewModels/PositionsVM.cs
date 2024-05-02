﻿namespace Luftborn.Server.ViewModels
{
	public class PositionsVM
	{
		public int Id { get; set; }
		public DateTime? CreationDate { get; set; }
		public DateTime? ModificationDate { get; set; }
		public string? CreatedBy { get; set; }
		public string? ModifyiedBy { get; set; }
		public string? CreatedByTeam { get; set; }
		public string? ModifyiedByTeam { get; set; }
		public bool? IsDeleted { get; set; } = false;
		public bool? IsEnabled { get; set; }

		public string Name { get; set; }
		public int DisplayOrder
		{
			get; set;
		}
	}
}
