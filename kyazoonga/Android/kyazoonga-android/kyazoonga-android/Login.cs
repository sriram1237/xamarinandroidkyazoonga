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

namespace kyazoongaandroid
{

	[Activity (Label = "kyazoonga")]			
	public class Login : Activity
	{
		public static int loginflag=0;
		EditText username, password;
		Button login;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.login);


			username = FindViewById<EditText> (Resource.Id.username);
			password = FindViewById<EditText> (Resource.Id.password);
			login = FindViewById<Button> (Resource.Id.login);
			login.Click += delegate {
				if (username.Text != "" && password.Text != "") {
					Toast.MakeText (this,"Login Successfully " , ToastLength.Short).Show ();
					StartActivity(typeof(Activity1));
					loginflag=1;
				} 

				else {
					//Item = username.Text;//.ToString();
					Toast.MakeText (this, "Enter User name and Password ", ToastLength.Short).Show ();


				
				}
			};


			// Create your application here
		}
	}
}

