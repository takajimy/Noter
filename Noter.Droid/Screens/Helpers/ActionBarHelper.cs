using System;
using System.Collections.Generic;
using System.IO;
using Noter.BL;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Views;

namespace Noter.Droid.Screens.Helpers
{
	public class ActionBarHelper
	{
		public void CreateAndAddActionBarTabs()
		{
			// Set the actionbar navigation mode to allow for tabs
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			SetContentView(Resource.Layout.Main);

			// Create new tabs
			ActionBar.Tab tab = ActionBar.NewTab();
			tab.SetText(Resources.GetString(Resource.String.tab1_text));
			tab.SetIcon(Resource.Drawable.tab1_icon);
			tab.TabSelected += (sender, args) => {
								   // Do something when tab is selected
							   }
							   
			// Add the new tabs to the action bar
			ActionBar.AddTab(tab);

			tab = ActionBar.NewTab();
			tab.SetText(Resources.GetString(Resource.String.tab2_text));
			tab.SetIcon(Resource.Drawable.tab2_icon);
			tab.TabSelected += (sender, args) => {
								   // Do something when tab is selected
							   }
			ActionBar.AddTab(tab);
		}
	}
}