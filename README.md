1.整体框架.

	场景切换功能：通过点击按钮进行空场景和主场景的切换。  
	每日精选部分实现商品展示与购买：通过读取json生成商品，并实现点击按钮进行购买功能。  
	士兵招募部分实现金币动画：点击按钮购买宝箱，飞出金币动画，并控制金币数量显示。  
2.界面结构. 

frontScene：空场景，只包括一个进入按钮，进行场景切换。      
mainScene：主场景，包括Scroll View、ReturnButton（返回按钮）、TotalCoin（总金币显示）、TotalDiamond（总钻石显示）. 
Scroll View：包括DailtPanel、CommodityPanel、SoldierPanel、
			    
3.代码结构. 

Control类：空场景和主场景切换功能。  

Commodity类：商品类，包括商品各属性信息。

Jsonread类：解析json并生成商品界面。 

Buy类：购买商品，并刷新为购买状态。

CoinMove类：购买宝箱，飞出金币动画。  


4.流程图

![flowPath](https://github.com/89trillion-hehuan/first/blob/master/flowPath.png)
