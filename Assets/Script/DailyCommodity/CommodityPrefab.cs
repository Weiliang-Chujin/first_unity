using System;
using System.Collections;
using System.Collections.Generic;
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
    
    [HideInInspector]
    public int num; //商品数量
    [HideInInspector]
    public int costNum; //商品单价

    //修改商品数量及其显示文字
    public void modifyCommodityNum(int addNum)
    {
        num += addNum;
        numText.text = String.Concat("x", num);
    }
    
    //修改商品下的购买按钮显示，state为0时，为购买按钮，state为1时，为已购买按钮
    public void modifyButtonState(int state)
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
