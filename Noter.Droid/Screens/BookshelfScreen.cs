using System;
using System.Collections.Generic;
using System.IO;
using Noter.BL;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Views;

namespace Noter.Droid.Screens
{
	[Activity (Label = "Tasky Pro", MainLauncher = true)]
	public class BookshelfScreen : Activity
	{
		
		protected override void OnCreate(Bundle bundle)
		{
			base.Oncreate(bundle);
			
			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);
			
			// Call ActionBar helper class
			ActionBarHelper.CreateAndAddActionBarTabs();
			
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		}
		
		protected override void OnResume()
		{
			
		}
	}
}
		
		
		
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