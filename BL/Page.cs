using System;
using System.Collections.Generic;

namespace Noter.BL
{
	public class Page
	{
		public string Title { get; set; }
				
		public bool showLabel { get; set; }
		
		public List<Line> lines { get; set; }
	}
}