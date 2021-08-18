using System;
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
	public PlayerInfoController playerInfoController; //玩家信息控制类
	public GameObject dailyPanel; //每日精选标题容器
    public GameObject commodityPanel; //商品容器

    public GameObject dailyTitlePrefab; //每日精选标题预制体
    public CommodityPrefab commodityPrefab; //商品预制体
    public GameObject lockPrefab; //lock商品的预制体

    private int count; //生成的商品计数
    private Commodity[] commodities; //保存商品json数据

    private void Awake()
    {
	    commodities = JsonReader.ReadJson();
    }

    void Start()
    {
	    count = 0;
	    CreateCommodity();
    } 
	
    //生成每日精选标题、商品和lock商品
    private void CreateCommodity()
    {
	    //添加每日精选标题
	    GameObject dailyTitleobj = Instantiate(dailyTitlePrefab, dailyPanel.transform);

		foreach (Commodity commodity in commodities)
        {
	        //生成商品
	        CommodityPrefab commodityobj = Instantiate(commodityPrefab, commodityPanel.transform);
	        commodityobj.commodity = commodity;
            count++;

            //初始化商品数量
            commodityobj.ModifyCommodityNum(commodityobj.commodity.num);
            
            //初始化商品图片
            commodityobj.ModifyCardBackground();
            
            //初始化商品按钮花费图片显示
            commodityobj.ModifyButtonShow();

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

    //购买商品
    private void Buy(CommodityPrefab commodityObject)
    {
	    //需花费的金币小于等于总金币且商品数量大于0，可以进行购买
	    if (commodityObject.commodity.costGold <= playerInfoController.totalCoin && commodityObject.commodity.num >= 0)
	    {
		    //修改总金币显示
		    playerInfoController.ModifyCoin(-commodityObject.commodity.costGold);
        
		    //修改商品数量显示
		    commodityObject.ModifyCommodityNum(-1);
        
		    //按钮变为已购买按钮
		    commodityObject.ModifyButtonState(1);
	    }
    }

}
