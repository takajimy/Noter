using System;
using System.Collections.Generic;
using System.IO;
using Noter.BL;

namespace Noter
{
	public class Bookshelf_Edit
	{
		public static void AddButtonClicked()
		{
			// Launch new view for filling out new shelf details
			
			
			// Add the new shelf
			Shelf shelf = new Shelf(myBookShelf.ID);
			
			// Add the new shelf to the Database
			Noter.Core.BL.ShelfManager.AddShelf(shelf);
			
			// Add the shelf to the bookshelf's shelf list
			myBookShelf.AddShelf(shelf);
		}
		
		public static void RemoveButtonClicked(Shelf shelf)
		{
			
			
		}
	}
	
	public class Bookshelf_View
	{
		public static void ShelfButtonClicked(Shelf shelf)
		{
			// Launch Shelf view with passed shelf
		}
	}
}