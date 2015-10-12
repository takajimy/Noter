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

namespace Noter.Droid.Activities
{
	abstract class BaseActivity : AppCompatActivity
	{
		DrawerLayout drawerLayout;

		protected void setupToolbar(Toolbar toolbar)
		{
			SetSupportActionBar (toolbar);
            SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}
		
		protected void setupNavigationView(NavigationView navigationView)
		{
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			if (navigationView != null)
			{
				navigationView.NavigationItemSelected += (sender, e) => {
					e.MenuItem.SetChecked (true);
					drawerLayout.CloseDrawers ();
				};
			}
		}
		
		protected void setupTabLayout(FragmentAdapter fragmentAdapter)
		{
			var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
			if (viewPager != null)
			{
				viewPager.Adapter = fragmentAdapter;
			}
			
			tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
			tabLayout.SetupWithViewPager(viewPager);
		}
		
		protected void setupFloatingActionButton()
		{
			addButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
			addButton.Click += (sender, e) => {
                Snackbar.Make (addButton, "Here's a snackbar!", Snackbar.LengthLong).SetAction("Action",
                    new ClickListener(v => {
                        Console.WriteLine("Action handler");
                    })).Show ();
            };
		}
		
		
	}
}
