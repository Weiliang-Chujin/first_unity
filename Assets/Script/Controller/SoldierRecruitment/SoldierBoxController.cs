using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
 * 士兵宝箱的控制类，包括生成士兵宝箱标题、士兵宝箱、金币，dotween实现金币动画
 */
public class SoldierBoxController : MonoBehaviour
{
    public GameObject canvas; //画布对象
    public GameObject shopPanel; //商店容器
    public GameObject coinPanel; //总金币容器
    public GameObject coinImage; //总金币图片
    public GameObject scrollView; //scrollView对象
    public GameObject viewPort; //viewPort对象
    public GameObject content; //content对象
    public GameObject soldierTitlePanel; //士兵招募标题容器
    public GameObject soldierBoxPanel; //宝箱容器
    public PlayerInfoController playerInfoController; //玩家信息控制类

    public GameObject soldierTitlePrefab; //士兵招募标题预制体
    public SoldierBoxPrefab soldierBoxPrefab; //士兵宝箱预制体
    public GameObject coinPrefab; //金币预制体

    private Vector3 startPosition; //金币初始位置
    private Vector3 targetPosition; //金币目标位置
    private int buyTimes; //购买次数
    private int coinNum; //每次要生成金币数量
    private int maxcoinNum; //一次生成最大金币数
    private float coinMoveTime; //金币移动到目标位置所需时间

    void Start()
    {
        buyTimes = 0;
        maxcoinNum = 15;
        coinMoveTime = 0.35f;
        CreateSoldierBox();
    }
    
    //生成士兵招募标题和紫色宝箱
    private void CreateSoldierBox()
    {
        GameObject soldierTitleobj = Instantiate(soldierTitlePrefab, soldierTitlePanel.transform);
        SoldierBoxPrefab soldierBoxobj =  Instantiate(soldierBoxPrefab, soldierBoxPanel.transform);
        
        soldierBoxobj.SoldierBoxBtn.onClick.AddListener(()=> { CoinAnimation(soldierBoxobj); });
    }
    
    //点击后生成金币，dotween实现金币动画
    private void CoinAnimation(SoldierBoxPrefab soldierBoxobj)
    {
        //限制生成金币数量
        buyTimes += 1;
        coinNum = buyTimes * 5;
        coinNum = Mathf.Clamp(coinNum, 0, maxcoinNum);
        
        //滚动视图滚动中要改变坐标，在这里计算金币初始位置和目标位置
        startPosition = shopPanel.transform.localPosition + scrollView.transform.localPosition + 
                        viewPort.transform.localPosition + content.transform.localPosition + 
                        soldierBoxPanel.transform.localPosition + soldierBoxobj.transform.localPosition;
        targetPosition = coinPanel.transform.localPosition + coinImage.transform.localPosition;
        
        //生成金币
        GameObject coin = Instantiate(coinPrefab, canvas.transform);
        coin.transform.localPosition = startPosition;
        
        //金币移动，到达目标位置，销毁金币，玩家总金币数增加
        coin.transform.DOLocalMove(targetPosition, coinMoveTime).SetLoops(coinNum,LoopType.Restart).OnStepComplete(() =>
        {
            playerInfoController.ModifyCoin(1);
        }).OnComplete((() => Destroy(coin)));
    }
}
