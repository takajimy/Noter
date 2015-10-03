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
	public Enum {
		
	}
	
	public static class SetupHelper
	{
		public static void setupToolbar(V7Toolbar toolbar)
		{
			SetSupportActionBar (toolbar);
            SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}
		
		public static void setupNavigationView(NavigationView navigationView)
		{
			if (navigationView != null)
			{
				navigationView.NavigationItemSelected += (sender, e) => {
					e.MenuItem.SetChecked (true);
					drawerLayout.CloseDrawers ();
				};
			}
		}
		
		public static void setupViewPager(ViewPager viewPager)
		{
			var adapter = new Adapter (SupportFragmentManager);
            adapter.AddFragment (new CheeseListFragment (), "Category 1");
            adapter.AddFragment (new CheeseListFragment (), "Category 2");
            adapter.AddFragment (new CheeseListFragment (), "Category 3");
            viewPager.Adapter = adapter;
		}
		
		public static void setupFloatingActionButton(FloatingActionButton button)
		{
			button.Click += (sender, e) => {
                Snackbar.Make (button, "Here's a snackbar!", Snackbar.LengthLong).SetAction ("Action",
                    new ClickListener (v => {
                        Console.WriteLine ("Action handler");
                    })).Show ();
            };
		}
		
		public static void setupTabLayout(TabLayout tabLayout, ViewPager viewPager);
		{
			tabLayout.SetupWithViewPager(viewPager);
		}
	}
}