using System;
using Noter.DL.SQLiteConnection;

namespace Noter.Core.BL.Base
{
	public abstract class BaseEntity : BusinessEntityBase
	{
		public string Title { get; set; }
		public bool showLabel { get; set; }
	}
}
