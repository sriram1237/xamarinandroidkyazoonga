using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using kyazoongaRest;
using System.Collections;
using Android.Util;

namespace kyazoongaandroid
{
	[Activity (Label = "kyazoonga" )]
	public class MainActivity : TabActivity
	{
		//public Boolean select=false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Tab);

			// Get our button from the layout resource,
			// and attach an event to it

			CreateTab(typeof(Cricket), "cricket", "cricket", Resource.Drawable.ic_tab_my_cricket);
			CreateTab(typeof(Events), "events", "events", Resource.Drawable.ic_tab_events);
			CreateTab(typeof(Theatre), "theatre", "theatre", Resource.Drawable.ic_tab_theatre);
			CreateTab(typeof(Sports), "sports", "sports", Resource.Drawable.ic_tab_sports);
			CreateTab(typeof(Store), "store", "store", Resource.Drawable.ic_tab_store);


			var text = Intent.GetStringExtra ("MyData") ?? "Data not available";
			Console.WriteLine (text);
			//TabHost.setcurr
			string tx = text.ToLower();

			TabHost.SetCurrentTabByTag (tx);



			//TabHost.SetCurrentTabByTag (2);
			//CreateTab(text, "cricket", "cricket", Resource.Drawable.ic_tab_my_cricket,select);
			//RestCall r=new RestCall();
			///ArrayList categoriesList=r.getCategoryItemList (2);
		
			//Console.WriteLine ("{0}  ",((CategoriesItem)categoriesList[1]).title);
			//StartActivity (typeof(text));
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

		//StartActivity (typeof(tes));


		private void CreateTab(Type activityType, string tag, string label, int drawableId )
		{
			var intent = new Intent(this, activityType);
			intent.AddFlags(ActivityFlags.NewTask);

			var spec = TabHost.NewTabSpec(tag);
			var drawableIcon = Resources.GetDrawable(drawableId);
			spec.SetIndicator(label, drawableIcon);
			spec.SetContent(intent);

			TabHost.AddTab(spec);
			//TabHost.SetCurrentTabByTag("events"); 

			Console.WriteLine (tag);

		}
		public void onBackPressed(){

			// do something here and don't write super.onBackPressed()
			Toast.MakeText (this, "back key pressed", ToastLength.Short).Show ();
		}
	}


}


