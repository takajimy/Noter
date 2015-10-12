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
	public class FragmentAdapter : Android.Support.V4.App.FragmentPagerAdapter 
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
