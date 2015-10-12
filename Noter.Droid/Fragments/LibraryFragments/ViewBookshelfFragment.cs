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
	public class ViewBookshelfFragment : Android.Support.V4.App.Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			return inflater.Inflate(Resource.Layout.recycler_view_frag, container, false);
        }
		
		public override void OnViewCreated(View view, Bundle bundle)
		{
			var bookshelf = BookshelfManager.getBookshelf();
			
			var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
			
			layoutManager = new LinearLayoutManager(Activity);
			recyclerView.SetLayoutManager(layoutManager);
			
			var adapter = new BookshelfAdapter(bookshelf);
			recyclerView.SetAdapter(adapter);
			
			base.OnViewCreated (view, bundle);
		}
	
		public class BookshelfRecyclerViewAdapter : RecyclerView.Adapter
		{
			public Bookshelf bookshelf;
			public int background;
			
			public class ViewHolder : RecyclerView.ViewHolder 
			{
				public string BoundString { get; set; }
				public View View { get;set; }
				public ImageView ImageView { get; set; }
				public TextView TextView { get; set; }

				public ViewHolder (View view, Action<int> listener) : base (view) 
				{
					View = view;
					ImageView = view.FindViewById<ImageView> (Resource.Id.avatar);
					TextView = view.FindViewById<TextView> (Android.Resource.Id.Text1);
				}

				public override string ToString () 
				{
					return base.ToString () + " '" + TextView.Text;
				}
			}
			
			public BookshelfRecyclerViewAdapter(Bookshelf pBookshelf)
			{
				bookshelf = pBookshelf;
				background = typedValue.ResourceId;
			}
			
			public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
			{
				var view = LayoutInflater.From (parent.Context).Inflate(Resource.Layout.list_item, parent, false);
				view.SetBackgroundResource (background);
				ViewHolder viewHolder = new ViewHolder(view, OnClick);
				return viewHolder;
			}
			
			public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
			{
				holder.BoundString = values[position];
				holder.TextView.Text = values[position];
				holder.View.Click += (sender, e) => {
					var context = holder.View.Context;
					var intent = new Intent(context, typeof(ShelfActivity));
					intent.PutExtra(CheeseDetailActivity.EXTRA_NAME, holder.BoundString);

					context.StartActivity(intent);
				};
				holder.ImageView.SetImageDrawable(Cheeses.GetRandomCheeseDrawable (parent));
			}
		}
	}
}
