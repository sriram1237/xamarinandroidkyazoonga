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
using System.Collections;
using kyazoongaRest;

namespace kyazoongaandroid
{
	[Activity (Label = "theatre")]			
	public class Theatre : Activity
	{
		ListView listView;
		ArrayList categoriesList;
		List<Tuple<string, string,string, int,string>> items;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//			TextView textview = new TextView (this);
			//			textview.Text = "This is the My Events tab";
			//			SetContentView (textview);
			RestCall r=new RestCall();
			categoriesList=r.getCategoryList (2);
			Console.WriteLine ("{0}  ",((CategoryList)categoriesList[0]).id);

			SetContentView(Resource.Layout.events);
			items = new List<Tuple<string, string,string, int,string>>();
			for (int i=0; i<categoriesList.Capacity; i++) {
				items.Add (new Tuple<string, string, string,int,string> (((CategoryList)categoriesList [i]).title, "venus :" + ((CategoryList)categoriesList [i]).venue, "date :", Resource.Drawable.loifl,((CategoryList)categoriesList [i]).id));
				//			items.Add(new Tuple<string, string,string, int>("Live Events", "24 Ghante Aapke Apne,Diwali", " date",Resource.Drawable.eventicon));
				//			items.Add(new Tuple<string, string, string,int>("Theatre & Arts", "KIngdom of Dreams-Zangoora,kingd", " date",Resource.Drawable.theatreartsicon));
				//			items.Add(new Tuple<string, string,string, int>("Sports", "I-League,shillong,Lajong Fc,Bung", " date",Resource.Drawable.sportsicon));
				//			items.Add(new Tuple<string, string, string,int>("Store", "Cricket,Music,Movies,Sports,Boo", " date",Resource.Drawable.storeicon));
				//			items.Add(new Tuple<string, string,string, int>("View Cart", "Your chart is empty", " date",Resource.Drawable.carticon));
				//			items.Add(new Tuple<string, string,string, int>("Transaction History", "View your transaction details"," date", Resource.Drawable.carticon));
				// Create your application here
				listView = FindViewById<ListView> (Resource.Id.List);
				listView.Adapter = new ImageAndTexts (this, items);

			}
			listView.ItemClick += OnListItemClick;
		}
		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{

			var listView = sender as ListView;
			var t = items[e.Position];
			Android.Widget.Toast.MakeText(this, t.Item1, Android.Widget.ToastLength.Short).Show();
			Console.WriteLine("Clicked on " + t);
			//StartActivity (typeof(MainActivity));
			var activity2 = new Intent (this, typeof(eventsitems));
			activity2.PutExtra ("MyData", t.Item5);
			StartActivity (activity2);
		}
	}
}

