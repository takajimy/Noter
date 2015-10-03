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
	public class BaseActivity : AppCompatActivity
	{
		V7Toolbar toolbar;
		DrawerLayout drawerLayout;
		NavigationView navigationView;
		
		protected override void OnCreate(Bundle bundle)
		{
			// Load any previous state of this activity and set view from main layout resource
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			
			// By default, set everything up
			setupToolbar();
			setupDrawerLayout();
			setupNavigationView();
		}
		
		protected void setupToolbar()
		{
			toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
            SupportActionBar.SetHomeAsUpIndicator (Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled (true);
		}
		
		protected void setupDrawerLayout()
		{
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
		}
		
		protected void setupNavigationView()
		{
			navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			if (navigationView != null)
			{
				navigationView.NavigationItemSelected += (sender, e) => {
					e.MenuItem.SetChecked (true);
					drawerLayout.CloseDrawers ();
				};
			}
		}
		
		protected override void OnResume()
		{
			
		}
	}
}
