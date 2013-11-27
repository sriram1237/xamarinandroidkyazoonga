using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Collections;

namespace kyazoongaRest
{
	public class RestCall
	{

		string categoryli="{'category_list': [{'id': 'le_1','title': 'Happy1','venue': 'chennai','image_url': 'photo.img','rating': '5'},{'id': 'le_2','title': 'Happy2','venue': 'chennai','image_url': 'photo.img','rating': '5'},{'id': 'le_3','title': 'Happy','venue': 'chennai','image_url': 'photo.img','rating': '5'},{'id': 'le_4','title': 'Happy','venue': 'chennai','image_url': 'photo.img','rating': '5'}]} ";
		string categoryItemli="{'categories_items': [{'id': 'le_1_v1','title': 'Happy999','venue': 'chennai','image_url': 'photo.img','rating': '5'},{'id': 'le_1_v2','title': 'Happy','venue': 'chennai','image_url': 'photo.img','rating': '5'}]}";
		string itemDetailsli="{'categories_item_details': {'item_category': [{'Date': '10-Nov-2013,11-nov-2013','Time': '10:30 pm,11:30 am','Name': 'Adult','Amount': '2000','Qty': '1,2,3,4,5,6'},{'Date': '10-Nov-2013,11-nov-2013','Time': '10:30 pm,11:30 am','Name': 'Adult','Amount': '2000','Qty': '1,2,3,4,5,6'}]}}";
		string storelist="{'product_id': 'cricket','product_items': [{'product_id': '12','name': 't-shirt','size': 's','price': '1000','mrp': '1200','save': '10%','color': 'white','qty': '4','details': 'white color T-shirt','img': '1.png'},{'product_id': '12','name': 't-shirt','size': 's','price': '1000','mrp': '1200','save': '10%','color': 'white','qty': '4','details': 'white color T-shirt','img': '1.png'},{'product_id': '12','name': 't-shirt','size': 's','price': '1000','mrp': '1200','save': '10%','color': 'white','qty': '4','details': 'white color T-shirt','img': '1.png'}],'related': [{'id': 'Bats'},{'id': 'Legguards'},{'id': 'Gloves'}]}";
		public RestCall ()
		{
			String val="hai surendran";

			Console.WriteLine ("{0}",val);
		}

		public string getValueString (){

			return "surendran";
		}

		public  string HttpGet(string url) {
			HttpWebRequest req = WebRequest.Create(url)
				as HttpWebRequest;
			string result = null;
			using (HttpWebResponse resp = req.GetResponse()as HttpWebResponse)
			{
				StreamReader reader =
					new StreamReader(resp.GetResponseStream());
				result = reader.ReadToEnd();
			}

		return result;
		}


		public  ArrayList getCategoryList(int paramid){
			string responseStr="";
			ArrayList catList = new ArrayList();
			try
			{

			 	responseStr=categoryli;
				JObject obj = JObject.Parse (responseStr);
				    
				StringBuilder builder = new StringBuilder();
				var categorylistObj= obj["category_list"];

				//categorylistObj[0]
				foreach(var item in categorylistObj){
					catList.Add(new CategoryList((string)item["id"],(string)item["title"],(string)item["venue"],(string)item["image_url"],(string)item["rating"]));
					builder.AppendLine((string)item["id"]);

				}

				/*foreach (var kvp in obj){
			 	  	var kvpValue =kvp.Value;
				   	foreach(var kvp2 in kvpValue){
				    	 var kvp2Value=JObject.FromObject(kvp2);
						//foreach (var kvp3 in kvp2Value){
							catList.Add(new CategoryList((string)kvp2Value["id"],(string)kvp2Value["title"],(string)kvp2Value["venue"],(string)kvp2Value["image_url"],(string)kvp2Value["rating"]))
						//builder.AppendLine ((string)kvp2Value["id"]);
						//}
				    }
		   		}*/
			
				 
				return catList;
			}
			catch (FormatException ex)
			{
				return new ArrayList();//ex.ToString();
			}
			catch (JsonException ex)
			{
				return new ArrayList();//ex.ToString();
			}


		}
		public  ArrayList getCategoryItemList(int paramid){
			string responseStr="";
			ArrayList itemList = new ArrayList();
			try
			{

				responseStr=categoryItemli;
				JObject obj = JObject.Parse (responseStr);

				StringBuilder builder = new StringBuilder();
				var categorylistObj= obj["categories_items"];

				//categorylistObj[0]
				foreach(var item in categorylistObj){
					itemList.Add(new CategoriesItem((string)item["id"],(string)item["title"],(string)item["venue"],(string)item["image_url"],(string)item["rating"]));
					builder.AppendLine((string)item["id"]);

				}

				return itemList;
			}
			catch (FormatException ex)
			{
				return new ArrayList();//ex.ToString();
			}
			catch (JsonException ex)
			{
				return new ArrayList();//ex.ToString();
			}


		}

		public  ArrayList getCategoryItemDetails(int paramid){
			string responseStr="";
			ArrayList itemList = new ArrayList();
			try
			{

				responseStr=itemDetailsli;
				JObject obj = JObject.Parse (responseStr);

				StringBuilder builder = new StringBuilder();
				var categorylistObj= obj["categories_item_details"]["item_category"];

				//categorylistObj[0]
				foreach(var item in categorylistObj){
					itemList.Add(new ItemCategory((string)item["Date"],(string)item["Time"],(string)item["Name"],(string)item["Amount"],(string)item["Qty"]));
					builder.AppendLine((string)item["Date"]);

				}

				return itemList;
			}
			catch (FormatException ex)
			{
				return new ArrayList();//ex.ToString();
			}
			catch (JsonException ex)
			{
				return new ArrayList();//ex.ToString();
			}


		}
		public  ProductItemRootObject getStoreList(int paramid){
			string responseStr="";
			ArrayList itemList = new ArrayList();
			try
			{

				responseStr=itemDetailsli;
				JObject obj = JObject.Parse (responseStr);

				StringBuilder builder = new StringBuilder();
				string  productId= (string)obj["product_id"];
				var productItems=obj["item_category"];
				var relatedItems=obj["related"];
				ArrayList productItemList=new ArrayList();
				foreach(var item in productItems){
					productItemList.Add(new ItemCategory((string)item["Date"],(string)item["Time"],(string)item["Name"],(string)item["Amount"],(string)item["Qty"]));
				}
				ArrayList relatedItemList=new ArrayList();
				foreach(var item in relatedItems){
					relatedItemList.Add(new Related((string)item["id"]));
				}
				 

				return new ProductItemRootObject(productId,productItemList,relatedItemList);
			}
			catch (FormatException ex)
			{
				return null;//ex.ToString();
			}
			catch (JsonException ex)
			{
				return null;//ex.ToString();
			}


		}

		/*public static Response MakeRequest(string requestUrl)
		{
			try
			{
				HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
				{
					if (response.StatusCode != HttpStatusCode.OK)
						throw new Exception(String.Format(
							"Server error (HTTP {0}: {1}).",
							response.StatusCode,
							response.StatusDescription));
					DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
					object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
					Response jsonResponse
						= objResponse as Response;
					return jsonResponse;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}

		}*/

		public String jsonParsing(String jsonStr){

			try
			{
				JObject obj = JObject.Parse (jsonStr);

				StringBuilder builder = new StringBuilder();
				foreach (var kvp in obj)
					builder.AppendLine (kvp.Key + " = " + kvp.Value);

				return builder.ToString();
			}
			catch (FormatException ex)
			{
			return ex.ToString();
			}
			catch (JsonException ex)
			{
			return ex.ToString();
			}
		}


		public  string HttpPost(string url, 
		                        string[] paramName, string[] paramVal)
		{
			HttpWebRequest req = WebRequest.Create(new Uri(url)) 
				as HttpWebRequest;
			req.Method = "POST";  
			req.ContentType = "application/x-www-form-urlencoded";

			// Build a string with all the params, properly encoded.
			// We assume that the arrays paramName and paramVal are
			// of equal length:
			StringBuilder paramz = new StringBuilder();
			for (int i = 0; i < paramName.Length; i++) {
				paramz.Append(paramName[i]);
				paramz.Append("=");
			//	paramz.Append(HttpUtility.UrlEncode(paramVal[i]));
				paramz.Append("&");
			}

			// Encode the parameters as form data:
			byte[] formData =
				UTF8Encoding.UTF8.GetBytes(paramz.ToString());
			req.ContentLength = formData.Length;

			// Send the request:
			using (Stream post = req.GetRequestStream())  
			{  
				post.Write(formData, 0, formData.Length);  
			}

			// Pick up the response:
			string result = null;
			using (HttpWebResponse resp = req.GetResponse()
			       as HttpWebResponse)  
			{  
				StreamReader reader = 
					new StreamReader(resp.GetResponseStream());
				result = reader.ReadToEnd();
			}

			return result;
		}


	
	}
}

