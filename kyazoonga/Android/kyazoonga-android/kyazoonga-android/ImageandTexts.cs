using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//namespace kyazoongaandroid
//{
//	[Activity (Label = "ImageandTexts")]			
//	public class ImageandTexts : Activity
//	{
//		protected override void OnCreate (Bundle bundle)
//		{
//			base.OnCreate (bundle);
//
//			// Create your application here
//		}
//	}
//}
using Android.Graphics;
using Android.Content.Res;


namespace kyazoongaandroid {
	//Since: API Level 1 
	public class ImageAndTexts : ArrayAdapter <Tuple<string,string,string,int,string>> {
		Activity context;
		public ImageAndTexts(Activity context, IList<Tuple<string, string, string,int,string>> objects)
			: base(context, Android.Resource.Id.Text1, objects)
		{
			this.context = context;

		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = context.LayoutInflater.Inflate(Resource.Layout.imageandtexts, null);
			var item = GetItem(position);


			view.FindViewById<TextView> (Resource.Id.Text1).Text = item.Item1;
			view.FindViewById<TextView> (Resource.Id.Text2).Text = item.Item2;
			view.FindViewById<TextView> (Resource.Id.Text3).Text = item.Item3;


			view.FindViewById<ImageView>(Resource.Id.Icon).SetImageResource(item.Item4);
			view.FindViewById<TextView> (Resource.Id.Text5).Text = item.Item5;
			return view;
		}
	}
}

