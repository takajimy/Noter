using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Collections.Generic;

namespace Noter.Droid
{
	[Activity (Label = "Noter", MainLauncher = true)]
	public static class DrawerSetup
	{
		public static void setupToolbar()
		{
			// Create toolbar and have it take on default support actionbar characteristics
			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}
		
		public static void setupDrawerContent()
		{
			var navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
            if (navigationView != null)
			{
				navigationView.NavigationItemSelected += (sender, e) => {
					e.MenuItem.SetChecked (true);
					drawerLayout.CloseDrawers ();
				};
			}
			
		}
		
		public static void setupViewPager (Android.Support.V4.View.ViewPager viewPager) 
        {
			var viewPager = FindViewById<Android.Support.V4.View.ViewPager> (Resource.Id.viewpager);
            if (viewPager != null)
			{
				var adapter = new Adapter (SupportFragmentManager);
				adapter.AddFragment (new CheeseListFragment (), "Category 1");
				adapter.AddFragment (new CheeseListFragment (), "Category 2");
				adapter.AddFragment (new CheeseListFragment (), "Category 3");
				viewPager.Adapter = adapter;
			}
        }
	}
}