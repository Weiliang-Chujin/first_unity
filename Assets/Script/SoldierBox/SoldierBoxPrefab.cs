using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 士兵宝箱预制体类，保存预制体的各子物体
 */
public class SoldierBoxPrefab : MonoBehaviour
{
    public GameObject soldierBox; //士兵宝箱游戏对象
    public Text soldierBoxName; //士兵宝箱名字
    public GameObject boxImagePanel; //士兵宝箱图片容器
    public Button SoldierBoxBtn; //士兵宝箱购买按钮
    public Image buyimage; //士兵宝箱购买图片
    public Text coinNum; //士兵宝箱单价
}
