using System;
using System.Collections;
namespace kyazoongaRest
{
	
	public class ProductItem
	{
		public ProductItem(){}
		public string product_id { get; set; }
		public string name { get; set; }
		public string size { get; set; }
		public string price { get; set; }
		public string mrp { get; set; }
		public string save { get; set; }
		public string color { get; set; }
		public string qty { get; set; }
		public string details { get; set; }
		public string img { get; set; }
	}

	public class Related
	{
		public Related(string idVal){
			this.id = idVal;
		}
		public string id { get; set; }
	}

	public class ProductItemRootObject
	{
		public ProductItemRootObject(string productid,ArrayList productItems,ArrayList relatedItems){	

			product_id = productid;
			productList = productItems;
			relatedList = relatedItems;

		}
		public string product_id { get; set; }
		public ArrayList productList { get; set; }
		public ArrayList relatedList { get; set; }
 
	}
}

