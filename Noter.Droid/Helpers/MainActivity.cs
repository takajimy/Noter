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
	public class MainActivity : Activity // ?
	{
		// What does this do?
		DrawerLayout drawerLayout;
		
		protected override void OnCreate(Bundle bundle)
		{
			// Load any previous state of this activity and set view from main layout resource
			base.Oncreate(bundle);
			SetContentView(Resource.Layout.Main);
			
			// Create Toolbar
			V7Toolbar toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetupHelper.setupToolbar(toolbar);
			
			// Create DrawerLayout
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			
			// Create NavigationView
			NavigationView navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			SetupHelper.setupNavigationView(navigationView);
			
			// Create ViewPager
			ViewPager viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
			SetupHelper.setupViewPager(viewPager);
			
			// Create FloatingActionButton
			FloatingActionButton addButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
			SetupHelper.setupFloatingActionButton(addButton);
			
			// Create TabLayout
			TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
			SetupHelper.setupTabLayout(tabLayout);
		}
		
		protected override void OnResume()
		{
			
		}
	}
}
