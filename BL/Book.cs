using System;
using System.Collections.Generic;

namespace Noter.BL
{
	public class Book
	{
		public string Title { get; set; }
				
		public bool showLabel { get; set; }
		
		public List<Page> pages { get; set; }
	}
}