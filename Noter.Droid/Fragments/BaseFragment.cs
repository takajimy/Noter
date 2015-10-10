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
	abstract class BaseFragment : Android.Support.V4.App.Fragment
	{
		public RecyclerView recyclerView;
		public RecyclerView.Adapter adapter;
		public RecyclerView.LayoutManager layoutManager;
		
		public override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
		}
		
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			var view = inflater.Inflate(Resource.Layout.recycler_view_frag, container, false);
			var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
			
			layoutManager = new LinearLayoutManager(Activity);
			recyclerView.SetLayoutManager(layoutManager);
			
			setupAdapter();
			
            return view;
        }
		
		protected void setupLayoutManager()
		{
			layoutManager = new LinearLayoutManager(Activity);
			recyclerView.SetLayoutManager(layoutManager);
		}
		
		protected void setupAdapter()
		{
			adapter = new BookshelfAdapter();
			recyclerView.SetAdapter(adapter);
		}
	}
}
