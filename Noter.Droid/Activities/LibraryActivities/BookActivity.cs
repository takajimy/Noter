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
	public class BookActivity : BaseActivity
	{
		ViewPager viewPager;
		TabLayout tabLayout;
		FloatingActionButton addButton;
		
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
			setupFloatingActionButton();
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
				adapter.AddFragment(new BookViewFragment(), "View");
				adapter.AddFragment(new BookEditFragment(), "Edit");
				viewPager.Adapter = adapter;
			}
		}
		
		protected void setupTabLayout()
		{
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
