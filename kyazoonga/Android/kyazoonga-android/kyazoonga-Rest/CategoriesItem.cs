using System;
using System.Collections;
namespace kyazoongaRest
{
	public class CategoriesItem
	{
		public CategoriesItem (string idVal,string titleVal,string venueVal,string imageVal,string ratingVal)
		{
			id = idVal;
			title = titleVal;
			venue = venueVal;
			image_url = imageVal;
			rating = ratingVal;

		}
		public string id { get; set; }
		public string title { get; set; }
		public string venue { get; set; }
		public string image_url { get; set; }

		public string rating { get; set; }
	}
	public class CategoriesItemRootObject
	{
		public CategoriesItemRootObject(){
		}
		//public List<CategoriesItem> categories_items { get; set; }
	}
}

