using System;
using System.Collections;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;

using Android.Widget;
using Android.OS;
using kyazoongaRest;

namespace kyazoongaandroid
{
	[Activity (Label = "kyazoonga-android")]
	public class MainActivity1 : Activity
	{
	//	int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			TextView tv = FindViewById<TextView> (Resource.Id.json_txt);
			RestCall r=new RestCall();
			ArrayList categoriesList=r.getCategoryItemDetails (2);
			tv.Text= string.Format ("{0}  ",((ItemCategory)categoriesList[1]).Name );

			button.Click += delegate {

				//r.getValueString();
			String returnType=r.HttpGet("http://api.geonames.org/citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demo");

				//button.Text = string.Format ("{0}  ",returnType/* count++*/);
			};
		}
	}
}




