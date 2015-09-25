using System;
using System.Collections.Generic;

namespace Noter.BL
{
	public class Widget
	{
		public string Title { get; set; }
				
		public bool showLabel { get; set; }
		
		public List<Book> books { get; set; }
	}
}