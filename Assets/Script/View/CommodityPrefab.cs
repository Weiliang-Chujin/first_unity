using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/*
 * 商品预制体类，保存商品预制体下的各子物体，以及对预制体的修改操作
 */
public class CommodityPrefab : MonoBehaviour
{
    public GameObject commodityobj; //商品物体
    public Text nameText; //商品名
    public Image cardBackground; //卡牌背景
    public Image cardImage; //商品图片
    public Text numText; //商品数量文字
    public GameObject buyBtnObj; //购买按钮对象
    public Button buyButton; //购买按钮
    public Image buyImage; //花费钻石或金币
    public Text costNumText; //商品单价文字
    public GameObject successBtnObj; //已购买按钮对象
    
    public Commodity commodity; //商品数据
    
    //修改卡牌图片或者钻石金币图片
    public void ModifyCardBackground()
    {
        StringBuilder stringBuilder = new StringBuilder();
        int randNumber = 0;
	    
        //利用随机数判断第一个格子是金币还是钻石
        System.Random random= new System.Random();
        randNumber = random.Next(1,3);
        
        //卡牌类型的图片初始化,使用紫色背景,不同类型的图片使用不同的卡牌
        if (commodity.type == 3) 
        {
            nameText.text = "卡牌";
            cardBackground.sprite = Resources.Load<Sprite>("Images/card_purple_bg");

            stringBuilder.Append("Images/");
            stringBuilder.Append(commodity.subType);
            cardImage.sprite = Resources.Load<Sprite>(stringBuilder.ToString());
            stringBuilder.Clear();
        } 
        //随机数判断显示是金币还是钻石，为1显示为金币，为2显示为钻石
        else
        {
            commodity.costGold = 0;
            costNumText.text = "0";
            cardBackground.sprite = Resources.Load<Sprite>("Images/card_coin_gem");
            if (randNumber == 1) 
            {
                nameText.text = "金币";
                cardImage.sprite = Resources.Load<Sprite>("Images/coin_1");
                buyImage.sprite = Resources.Load<Sprite>("Images/coin");
            }
            else 
            { 
                nameText.text = "钻石"; 
                cardImage.sprite = Resources.Load<Sprite>("Images/diamond_2"); 
                buyImage.sprite = Resources.Load<Sprite>("Images/Gem");
            }
        }
    }

    //修改商品数量及其显示文字
    public void ModifyCommodityNum()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("x");
        stringBuilder.Append(commodity.num);
        numText.text = stringBuilder.ToString();
    }
    
    //修改商品按钮上花费图片显示
    public void ModifyButtonShow()
    {
        //初始化商品按钮上花费金币数和金币图片显示
        if (commodity.costGold > 0) 
        {
            costNumText.text = commodity.costGold.ToString();
            buyImage.sprite = Resources.Load<Sprite>("Images/coin");
        } 
        //初始化商品按钮上花费钻石数和钻石图片显示
        else if (commodity.costGem > 0) 
        {
            costNumText.text = commodity.costGem.ToString();
            buyImage.sprite = Resources.Load<Sprite>("Images/Gem");
        } 
    }
    
    //修改商品下的购买按钮，state为0时，为购买按钮，state为1时，为已购买按钮
    public void ModifyButtonState(int state)
    {
        if (state == 0)
        {
            buyBtnObj.SetActive(true);
            successBtnObj.SetActive(false);
        }
        else
        {
            buyBtnObj.SetActive(false);
            successBtnObj.SetActive(true);
        }
    }
}
