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
	public class BookshelfActivity : BaseActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.Oncreate(bundle);
			SetContentView(Resource.Layout.Main);

			// Toolbar
			var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			setupToolbar(toolbar);
			
			// NavigationView and DrawerLayout
			var navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			setupNavigationView(navigationView);
			
			// ViewPager and TabLayout
			var fragmentAdapter = new FragmentAdapter(SupportFragmentManager);
			fragmentAdapter.AddFragment(new BookshelfViewFragment(), "View");
			fragmentAdapter.AddFragment(new BookshelfEditFragment(), "Edit");
			setupTabLayout(fragmentAdapter);
			
			// FAB
			setupFloatingActionButton();
		}
		
		public override bool OnCreateOptionsMenu (IMenu menu) 
        {
            MenuInflater.Inflate(Resource.Menu.sample_actions, menu);
            return true;
        }
            
        public override bool OnOptionsItemSelected (IMenuItem item) 
        {
            switch (item.ItemId) {
            case Android.Resource.Id.Home:
                drawerLayout.OpenDrawer (Android.Support.V4.View.GravityCompat.Start);
                return true;
            }
            return base.OnOptionsItemSelected (item);
        }
		
		public class ClickListener : Java.Lang.Object, View.IOnClickListener
		{
			public ClickListener (Action<View> handler)
			{
				Handler = handler;
			}

			public Action<View> Handler { get; set; }

			public void OnClick (View v)
			{
				var h = Handler;
				if (h != null)
					h (v);
			}
		}
	}
}
