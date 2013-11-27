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

using Java.Lang;
using System.Threading.Tasks;



namespace kyazoongaandroid
{
    

	//[Activity(Theme = "@style/Theme.Splash", MainLauncher = true ,NoHistory = true)]
	[Activity( NoHistory = true,MainLauncher = true)]
    public class SplashActivity : Activity
	{ 

        protected override void OnCreate(Bundle bundle)
		{
			try{
			
			base.OnCreate (bundle);
			//ImageView imageView1 = new ImageView(this);
		//imageView1.SetImageResource(Resource.Drawable.kyazoongaogo);
			SetContentView(Resource.Layout.splashscreen);
				Handler myHandler = new Handler();

				new System.Threading.Thread(new System.Threading.ThreadStart(() => {
					 // should NOT reference UILabel on background thread!
					Thread.Sleep(5000);
					if (Login.loginflag == 1) 
					{
						Console.Write(Login.loginflag);
						StartActivity (typeof(Activity1));
					} else 
					{
						Console.Write(Login.loginflag);
						StartActivity (typeof(Login));
					} 
				})).Start();



//				if (Login.loginflag == 1) 
//				{
//					Console.Write(Login.loginflag);
//					StartActivity (typeof(Activity1));
//				} else 
//				{
//					Console.Write(Login.loginflag);
//					StartActivity (typeof(Login));
//				} 


			
		}catch(Java.Lang.Exception e){
				Console.Write("Hai"+e);

		}

    }
		public void sleep()
		{	
			Thread.Sleep (5000);
		}
//
//		}; 

}		
}
