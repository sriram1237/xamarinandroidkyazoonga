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
using Android.Graphics;

namespace kyazoongaandroid
{
	[Activity (Label = "cart")]			
	public class cart : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.cart);


			ImageView iv1=FindViewById<ImageView> (Resource.Id.imageView2);

			var bmp = BitmapFactory.DecodeResource (Resources, Resource.Drawable.beach);
			iv1.SetImageDrawable(new round (bmp, cornerRadius: 20, withEffect: true));
			//TextView textview = new TextView (this);
			//textview.Text = "This is the My cart";
			//SetContentView (textview);
			// Create your application here
			//ImageButton card= FindViewById<ImageButton> (Resource.Id.cart);

			//card.Click += delegate {
				//StartActivity (typeof(cart));
				//Toast.MakeText (this, "image button pressed", ToastLength.Short).Show ();
			//};
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
	}
}

