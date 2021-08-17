using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

/*
 * json读取类，读取商品的json数据
 */
public class JsonReader 
{
	
	//读取商品的json数据
    public static Commodity[] ReadJson()
    {
	    //解析并读取json
	    TextAsset txtobj = (TextAsset) Resources.Load("Json/data");
	    JSONNode json = JSONNode.Parse(txtobj.text);
	    JSONNode data = json["dailyProduct"];

	    //数据存入商品数据类的数组中
	    var commodity = new Commodity[data.Count];
	    for (int i = 0; i < data.Count; i++)
	    {
		    var fieldRead = new Commodity()
		    {
			    productId = data[i]["productId"],
			    type = data[i]["type"],
			    subType = data[i]["subType"],
			    num = data[i]["num"],
			    costGold = data[i]["costGold"],
			    costGem = data[i]["costGem"],
			    isPurchased = data[i]["isPurchased"]
		    };
		    commodity[i] = fieldRead;
	    }

	    return commodity;
    }
    
}

