using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/*
 * 商品控制类，生成商品，并初始化其子物体各信息显示，购买商品操作
 */
public class CommodityController : MonoBehaviour
{
	public GameObject dailyPanel; //每日精选标题容器
    public GameObject commodityPanel; //商品容器
    public PlayerInfoController playerInfoController; //玩家信息控制类
    public JsonReader jsonReader; //读取json数据类

    public GameObject dailyTitlePrefab; //每日精选标题预制体
    public CommodityPrefab commodityPrefab; //商品预制体
    public GameObject lockPrefab; //lock商品的预制体

    private int count; //生成的商品计数

    void Start()
    {
	    count = 0;
	    CreateCommodity(jsonReader.commodities);
    } 
	
    //生成每日精选标题、商品和lock商品
    public void CreateCommodity(Commodity[] commodities)
    {
	    //添加每日精选标题
	    GameObject dailyTitleobj = Instantiate(dailyTitlePrefab, dailyPanel.transform);

		foreach (Commodity commodity in commodities)
        {
	        //生成商品
	        CommodityPrefab commodityobj = Instantiate(commodityPrefab, commodityPanel.transform);
            count++;

            //初始化商品子物体的各信息
            InitializeInfo(commodity, commodityobj);

            //商品购买按钮激活，购买成功按钮关闭，购买按钮绑定购买事件
			commodityobj.ModifyButtonState(0);
            commodityobj.buyButton.onClick.AddListener(()=> { Buy(commodityobj); });
        }
        
        //商品数量不够3的倍数时添加lock商品
	    while (count % 3 != 0)
	    { 
		    GameObject lockobj = Instantiate(lockPrefab, commodityPanel.transform);
		  	count++;
	    }
    }
    
    //初始化商品子物体的各信息
    public void InitializeInfo(Commodity commodity, CommodityPrefab commodityObject)
    {
	    StringBuilder stringBuilder = new StringBuilder();
	    int number = 0;
	    
	    //利用随机数判断第一个格子是金币还是钻石
	    System.Random random= new System.Random();
	    number = random.Next(1,3);

	    //初始化商品数量
	    commodityObject.ModifyCommodityNum(commodity.num);
		
	    //卡牌类型的图片初始化,使用紫色背景,不同类型的图片使用不同的卡牌
	    if (commodity.type == 3) 
	    {
		    commodityObject.nameText.text = "卡牌";
		    commodityObject.cardBackground.sprite = Resources.Load<Sprite>("Images/card_purple_bg");

		    stringBuilder.Append("Images/");
		    stringBuilder.Append(commodity.subType);
		    commodityObject.cardImage.sprite = Resources.Load<Sprite>(stringBuilder.ToString());
		    stringBuilder.Clear();
	    } 
	    //随机数判断显示是金币还是钻石，为1显示为金币，为2显示为钻石
	    else
	    {
		    commodityObject.costNum = 0;
		    commodityObject.costNumText.text = "0";
		    commodityObject.cardBackground.sprite = Resources.Load<Sprite>("Images/card_coin_gem");
		    if (number == 1) 
		    {
			    commodityObject.nameText.text = "金币";
			    commodityObject.cardImage.sprite = Resources.Load<Sprite>("Images/coin_1");
			    commodityObject.buyImage.sprite = Resources.Load<Sprite>("Images/coin");
		    }
		    else 
		    { 
			    commodityObject.nameText.text = "钻石"; 
			    commodityObject.cardImage.sprite = Resources.Load<Sprite>("Images/diamond_2"); 
			    commodityObject.buyImage.sprite = Resources.Load<Sprite>("Images/Gem");
		    }
	    }
		
	    //初始化商品按钮上花费金币数和金币图片显示
	    if (commodity.costGold > 0) 
	    {
		    commodityObject.costNum = commodity.costGold;
		    commodityObject.costNumText.text = commodity.costGold.ToString();
		    commodityObject.buyImage.sprite = Resources.Load<Sprite>("Images/coin");
	    } 
	    //初始化商品按钮上花费钻石数和钻石图片显示
	    else if (commodity.costGem > 0) 
	    {
		    commodityObject.costNum = commodity.costGem;
		    commodityObject.costNumText.text = commodity.costGem.ToString();
		    commodityObject.buyImage.sprite = Resources.Load<Sprite>("Images/Gem");
	    } 
         
	} //InitializeInfo方法结束
    
    //购买商品
    public void Buy(CommodityPrefab commodityObject)
    {
	    //需花费的金币小于等于总金币且商品数量大于0，可以进行购买
	    if (commodityObject.costNum <= playerInfoController.totalCoin && commodityObject.num >= 0)
	    {
		    //修改总金币显示
		    playerInfoController.ModifyCoin(-commodityObject.costNum);
        
		    //修改商品数量显示
		    commodityObject.ModifyCommodityNum(-1);
        
		    //按钮变为已购买按钮
		    commodityObject.ModifyButtonState(1);
	    }
    }

}
