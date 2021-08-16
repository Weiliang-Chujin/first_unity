using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 商品类,用于保存商品数据
 */
public class Commodity 
{
    public int productId; //商品id
    public int type; //商品类型
    public int subType; //商品子类型
    public int num; //商品数量
    public int costGold; //商品花费金币数
    public int costGem; //商品花费钻石数
    public int isPurchased; //商品是否已购买
}
