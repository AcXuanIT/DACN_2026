using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("UI")]
    [SerializeField] private UiInGameManger _uiInGameManager;
    [SerializeField] private UIBuilder _uiBuilder;
    [SerializeField] private UISetting _uiSetting;
    [SerializeField] private UISettingMusic _uiSettingMusic;
    [SerializeField] private UILose _uiLose;
    [SerializeField] private UIRank _uiRank;
    [SerializeField] private UIPause _uiPause;
    [SerializeField] private UIShop _uiShop;
    [SerializeField] private UIInGame _uiInGame;

    [Header("UI Object")]
    [SerializeField] private GameObject UItop;
    [SerializeField] private GameObject UImid;
    [SerializeField] private GameObject UIbuttom;

    [Header("UI Animation")]
    [SerializeField] private UIAnimation _uiAnimation;


    public UiInGameManger InGameManagerUI => _uiInGameManager;
    public UIBuilder BuilderUI => _uiBuilder;
    public UISetting SettingUI => _uiSetting;
    public UISettingMusic SettingMusicUI => _uiSettingMusic;
    public UILose LoseUI => _uiLose;
    public UIRank RankUI => _uiRank;
    public UIPause PauseUI => _uiPause;
    public UIShop ShopUI => _uiShop;
    public UIInGame GameUI => _uiInGame;

    public GameObject UITop => UItop;
    public GameObject UIMid => UImid;
    public GameObject UIButtom => UIbuttom;


    //animation
    public UIAnimation AnimationUI => _uiAnimation;
}
