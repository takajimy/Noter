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
	public class BookshelfActivity : BaseActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			// Load any previous state of this activity and set view from main layout resource
			base.Oncreate(bundle);
			SetContentView(Resource.Layout.Main);
			
			setupToolbar();
			setupDrawerLayout();
			setupNavigationView();
			
			// Create ViewPager and add fragments for view and edit tabs
			ViewPager viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
			if (viewPager != null)
			{
				var adapter = new Adapter (SupportFragmentManager);
				adapter.AddFragment (new CustomFragment(), "View");
				adapter.AddFragment (new CustomFragment(), "Edit");
				viewPager.Adapter = adapter;
			}
			
			// Create TabLayout and set it up with the previously created ViewPager
			TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
			tabLayout.SetupWithViewPager(viewPager);
			
			// Create FloatingActionButton
			FloatingActionButton addButton = FindViewById<FloatingActionButton>(Resource.Id.fab);
			addButton.Click += (sender, e) => {
                Snackbar.Make (addButton, "Here's a snackbar!", Snackbar.LengthLong).SetAction ("Action",
                    new ClickListener (v => {
                        Console.WriteLine ("Action handler");
                    })).Show ();
            };
		}
		
		protected override void OnResume()
		{
			
		}
	}
}
