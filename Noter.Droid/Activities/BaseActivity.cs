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
		
		protected void setupTabLayout(Adapter adapter)
		{
			var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
			if (viewPager != null)
			{
				viewPager.Adapter = adapter;
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
		
		class Adapter : Android.Support.V4.App.FragmentPagerAdapter 
        {
            List<V4Fragment> fragments = new List<V4Fragment> ();
            List<string> fragmentTitles = new List<string> ();

            public Adapter (V4FragmentManager fm) : base (fm)
            {
            }

            public void AddFragment (V4Fragment fragment, String title) 
            {
                fragments.Add(fragment);
                fragmentTitles.Add(title);
            }
                
            public override V4Fragment GetItem(int position) 
            {
                return fragments [position];
            }

            public override int Count {
                get { return fragments.Count; }
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
            {
                return new Java.Lang.String (fragmentTitles [position]);
            }

        }
	}
}
