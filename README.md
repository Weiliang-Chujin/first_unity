### 1.整体框架  

 切换界面功能：通过点击按钮进行空界面和商店界面的切换。     
 每日精选部分实现商品展示与购买：通过读取json数据动态生成商品，并初始化其信息，商品数量不够3的倍数生成lock商品，并实现点击按钮进行购买功能。    
 士兵招募部分实现金币动画：点击按钮购买宝箱，使用dotween做金币动画，金币到达目的点修改玩家金币数。   

### 2.界面结构     

 EmptyPanel：空界面，只包括一个进入按钮，进行界面切换。    
 ControlEvent：空物体，用来绑定脚本。  
 ShopPanel：商店界面，包括ScrollView、ExitButton（退出按钮）、CoinPanel（总金币显示容器）、DiamondPanel（总钻石显示容器)。

 ScrollView：每日精选部分包括DailyTitlePanel（每日精选标题容器）、CommodityPanel（商品容器），士兵招募部分包括SoldierTitlePanel（士兵招募标题容器）、SoldierBoxPanel（士兵宝箱容器）

 预制体有7个：每日精选部分包括DailyTitle（每日精选标题）、Commodity（商品）、Lock（lock商品），士兵招募部分包括SoldierTitle（士兵招募标题）、SoldierBox（士兵宝箱）、SpecialEfficiency（宝箱特效）、Coin（金币）
			    
### 3.代码结构

| 类名                 | 功能                                                     | 调用关系                                                     |
| -------------------- | -------------------------------------------------------- | ------------------------------------------------------------ |
| Commodity            | 保存商品数据                                             | 被JsonReader类、CommodityController类调用                    |
| CommodityPrefab      | 保存商品预制体下的子物体，修改商品数量，修改购买按钮显示 | 被CommodityController类调用                                  |
| SoldierBoxPrefab     | 保存士兵宝箱预制体下的子物体                             | 被SoldierBoxController类调用                                 |
| JsonReader           | 读取商品json数据                                         | 调用Commodity类，被CommodityController类调用                 |
| GameController       | 控制切换界面                                             | 无                                                           |
| PlayerInfoController | 管理玩家的金币数和钻石数                                 | 被CommodityController类和SoldierBoxController类调用          |
| CommodityController  | 生成商品、初始化商品信息和购买商品                       | 调用Commodity类、JsonReader类、CommodityPrefab类和PlayerInfoController类 |
| SoldierBoxController | 生成士兵宝箱标题、士兵宝箱、金币，dotween实现金币动画    | 调用SoldierBoxPrefab类和PlayerInfoController类               |


### 4.流程图

![flowPath](https://github.com/89trillion-hehuan/first_test/blob/main/FlowChart.png)
