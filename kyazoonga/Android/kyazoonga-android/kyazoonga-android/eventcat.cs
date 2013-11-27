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
using kyazoongaRest;
using System.Collections;
using Android.Graphics;

namespace kyazoongaandroid
{
	[Activity (Label = "eventcat")]			
	public class eventcat : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.eventcat);
			TextView tv = FindViewById<TextView> (Resource.Id.txt);
			TextView tv1 = FindViewById<TextView> (Resource.Id.txt1);
			TextView tv2 = FindViewById<TextView> (Resource.Id.txt2);
			//var imageView=FindViewById<ImageView> (Resource.Id.imageView3);
			//var bmp = BitmapFactory.DecodeResource (Resources, Resource.Drawable.loifl);
			//imageView.SetImageDrawable(new round (bmp, cornerRadius: 20, withEffect: true));

			RestCall r=new RestCall();
			ArrayList categoriesList=r.getCategoryItemDetails (2);
			tv.Text= string.Format ("{0}  "," Date: "+((ItemCategory)categoriesList[1]).Date);
			tv1.Text= string.Format ("{0}  "," Time: "+((ItemCategory)categoriesList[1]).Time);
			tv2.Text= string.Format ("{0}  ", " Amount: "+((ItemCategory)categoriesList[1]).Amount);
			// Create your application here

			Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner);
			Spinner spinner2 = FindViewById<Spinner> (Resource.Id.spinner2);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (this, Resource.Array.cat_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;


			spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter1 = ArrayAdapter.CreateFromResource (this, Resource.Array.qty_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapter1.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner2.Adapter = adapter1;
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
		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			//Button bt = new Button (this);
			//bt.Text = "click";
			//LinearLayout ll = (LinearLayout)FindViewById(Resource.Id.lp);
			//Android.Widget.LinearLayout.LayoutParams lp = new Android.Widget.LinearLayout.LayoutParams(100,100);
			//ll.AddView(bt, lp);
			//Spinner spinner = (Spinner)sender;
			//string toast = string.Format ("The planet is {0}", spinner.GetItemAtPosition (e.Position));
			//Toast.MakeText (this, toast, ToastLength.Long).Show ();


		}

	}
}

