using System;


namespace kyazoongaRest
{
	public class ItemCategory
	{
		public ItemCategory( string date,string time,string name,string amount,string qty){

			Date = date;
			Time = time;
			Name = name;
			Amount = amount;
			Qty = qty;

		}
		public string Date { get; set; }
		public string Time { get; set; }
		public string Name { get; set; }
		public string Amount { get; set; }
		public string Qty { get; set; }
	}

	public class CategoriesItemDetails
	{
		public CategoriesItemDetails ()
		{
		}
		//public List<ItemCategory> item_category { get; set; }
	}
	public class CategoriesItemDetailsRootObject
	{
		public CategoriesItemDetailsRootObject(){
		}
		public CategoriesItemDetails categories_item_details { get; set; }
	}
}

