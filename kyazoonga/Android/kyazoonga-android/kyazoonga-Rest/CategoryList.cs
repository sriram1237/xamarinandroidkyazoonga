using System;

namespace kyazoongaRest
{
	public class CategoryList
	{
		public CategoryList (string idVal,string titleVal,string venueVal,string imageVal,string ratingVal)
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
	public class CategoryListRootObject
	{

		public CategoryListRootObject(){
		}

		//public List<CategoryList> category_list { get; set; }
	}
}

