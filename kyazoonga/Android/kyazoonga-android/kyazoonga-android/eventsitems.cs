using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using kyazoongaRest;
using System.Collections;
using Android.Util;
using System.Collections.Generic;
using Java.Util;
using System.Text.RegularExpressions;
using Android.Graphics;

namespace kyazoongaandroid
{
	[Activity (Label = "eventsitems")]			
	public class eventsitems : Activity
	{
		ListView listView;
		System.Collections.ArrayList categoriesItem;
		List<Tuple<string, string,string, int,string>> items;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.eventitems);
			string text = Intent.GetStringExtra ("MyData") ?? "Data not available";
			Console.WriteLine (text);

			String[] st = Regex.Split(text,"_");
			int n = Convert.ToInt32 (st [1]);
			Console.WriteLine (n);
//			while (st.HasMoreElements) {
//				Console.WriteLine (st.NextElement());
//			}
			try{
			
				//var bmp = BitmapFactory.DecodeResource (Resources, Resource.Drawable.loifl);
			/// var obj=new round (bmp, cornerRadius: 20, withEffect: true);

				//int x = (int)obj;

			RestCall r=new RestCall();
			categoriesItem=r.getCategoryItemList (2);
			Console.WriteLine ("{0}  ",((CategoriesItem)categoriesItem[n-1]).id);
			items = new List<Tuple<string, string,string, int,string>>();
				items.Add (new Tuple<string, string, string,int,string> (((CategoriesItem)categoriesItem [n-1]).title, "venus :" + ((CategoriesItem)categoriesItem [n-1]).venue, "date :26-11-2013", Resource.Drawable.loifl,((CategoriesItem)categoriesItem [n-1]).id));
		
			listView = FindViewById<ListView> (Resource.Id.List);
			listView.Adapter = new ImageAndTexts (this, items);
				listView.ItemClick += OnListItemClick;
			}catch(Exception e)
			{
			}
			ImageButton cart= FindViewById<ImageButton> (Resource.Id.cart);

			cart.Click += delegate {
				StartActivity (typeof(cart));
				//Toast.MakeText (this, "image button pressed", ToastLength.Short).Show ();
			};
			Button logout= FindViewById<Button> (Resource.Id.angry_btn);
			if (Login.loginflag == 1) {
				logout.Text = string.Format ("Logout");
			} else if(Login.loginflag == 0)  {
				logout.Text = string.Format ("sign in");
			}
			logout.Click += delegate {
				if (Login.loginflag == 1) 
				{
					Console.Write(Login.loginflag);

					logout.Text = string.Format ("sign in");
					Login.loginflag =0;

				} else  
				{
					Console.Write(Login.loginflag);
					StartActivity (typeof(Login));
					logout.Text = string.Format ("signin");
					//Toast.MakeText (this, "loged out successfully", ToastLength.Short).Show ();
				} 

			};
		}
			protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
			{

				var listView = sender as ListView;
				var t = items[e.Position];
				Android.Widget.Toast.MakeText(this, t.Item1, Android.Widget.ToastLength.Short).Show();
				Console.WriteLine("Clicked on " + t);
				//StartActivity (typeof(eventcat));
				var activity2 = new Intent (this, typeof(eventcat));
				activity2.PutExtra ("MyData", t.Item5);
				StartActivity (activity2);
			}
		



			// Create your application here
		}
	}


