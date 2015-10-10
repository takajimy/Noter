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

namespace Noter.Droid.Activities.LibraryActivities
{
	[Activity(Label = "Noter", MainLauncher = true)]
	public class PageActivity : BaseActivity
	{
		ViewPager viewPager;
		TabLayout tabLayout;
		
		protected override void OnCreate(Bundle bundle)
		{
			// Load any previous state of this activity and set view from main layout resource
			base.Oncreate(bundle);
			SetContentView(Resource.Layout.Main);
			
			// Setup UI components
			setupToolbar();
			setupDrawerLayout();
			setupNavigationView();
			setupViewPager();
			setupTabLayout();
		}
		
		protected override void OnResume()
		{
			
		}
		
		protected void setupViewPager()
		{
			viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
			if (viewPager != null)
			{
				var adapter = new Adapter(SupportFragmentManager);
				adapter.AddFragment(new PageViewFragment(), "View");
				adapter.AddFragment(new PageEditFragment(), "Edit");
				viewPager.Adapter = adapter;
			}
		}
		
		protected void setupTabLayout()
		{
			tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
			tabLayout.SetupWithViewPager(viewPager);
		}
	}
}
