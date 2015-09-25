using System;
using Noter.DL.SQLiteConnection;

namespace Noter.BL.Base
{
	public abstract class BusinessEntityBase : IBusinessEntity 
	{
		public BusinessEntityBase () {}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
	}
}
