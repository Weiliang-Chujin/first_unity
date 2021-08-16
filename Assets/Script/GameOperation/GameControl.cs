using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * 程序控制类，控制切换界面
 */
public class GameControl : MonoBehaviour
{
    public GameObject shopPanel; //商店界面
    public GameObject emptyPanel; //空界面

    void Start()
    {
        shopPanel.SetActive(false);
        emptyPanel.SetActive(true);
    } 
        
    //进入商店界面
    public void Enter()
    {
        shopPanel.SetActive(true);
        emptyPanel.SetActive(false);
    }
    
    //退出商店界面
    public void Exit()
    {
        shopPanel.SetActive(false);
        emptyPanel.SetActive(true);
    }
    
}