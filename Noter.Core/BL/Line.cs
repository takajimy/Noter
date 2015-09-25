using System;
using System.Collections.Generic;

namespace Noter.BL
{
	public class Line
	{
		public string Title { get; set; }
				
		public bool showLabel { get; set; }
		
		public List<Content> content { get; set; }
	}
}