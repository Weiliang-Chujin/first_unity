using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 玩家管理者类，管理玩家的金币数和钻石数
 */
public class PlayerManager : MonoBehaviour
{
    public Text totalCoinText; //总金币显示文字
    [HideInInspector]
    public int totalCoin; //总金币数量
    public Text totalDiamondText; //总钻石显示文字
    [HideInInspector]
    public int totalDiamond; //总钻石数量
    
    void Start()
    {
        totalCoin = 50000;
        totalDiamond = 1000;
        ModifyCoin(0);
        ModifyDiamond(0);
    }

    //修改玩家金币数
    public void ModifyCoin(int addCoin)
    {
        totalCoin += addCoin;
        totalCoinText.text = totalCoin.ToString();
    }
    
    //修改玩家钻石数
    public void ModifyDiamond(int addDiamond)
    {
        totalDiamond += addDiamond;
        totalDiamondText.text = totalDiamond.ToString();
    }
}
