using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInGameManger : MonoBehaviour
{
    [Header("Button Buttom")]
    [SerializeField] private Button btnPlayGame;
    [SerializeField] private Button btnBuilder;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnNextRight;
    [SerializeField] private Button btnNectLeft;

    [Header("Button Top")]
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnMultiplayer;
    [SerializeField] private Button btnFire;
    [SerializeField] private Button btnRank;
    [SerializeField] private GameObject scoreRank;

    [Header("Button In Game")]
    [SerializeField] private Button btnPause;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject score;

    private void Awake()
    {
        //Bottom
        btnPlayGame.onClick.AddListener(() =>
        {
            Debug.Log("On Click Button Play Game");

            InGameManager.Instance.StartGame();
            TurnOffButton();
            TurnOnButtonInGame();

            DOVirtual.DelayedCall(1f, () =>
            {
                CloseUIInGame();
                DOVirtual.DelayedCall(1.2f, () => {
                    UIManager.Instance.GameUI.Open();
                });
            });

        });
        btnBuilder.onClick.AddListener(() =>
        {
            CloseUIInGame();
            UIManager.Instance.BuilderUI.Open();
        });
        btnShop.onClick.AddListener(() =>
        {
            CloseUIInGame();
            UIManager.Instance.ShopUI.Open();
        });

        //Top
        btnSetting.onClick.AddListener(() =>
        {
            CloseUIInGame();
            UIManager.Instance.SettingUI.Open();
        });
        btnRank.onClick.AddListener(() =>
        {
            CloseUIInGame();
        });

    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void TurnOnButton()
    {
        TurnButton(true);
    }
    public void TurnOffButton()
    {
        TurnButton(false);
    }
    public void TurnOnButtonInGame()
    {
        TurnButtonInGame(true);
    }
    public void TurnOffButtonInGame()
    {
        TurnButtonInGame(false);
    }
    public void TurnButton(bool val)
    {
        btnPlayGame.gameObject.SetActive(val);
        btnBuilder.gameObject.SetActive(val);
        btnShop.gameObject.SetActive(val);
        btnNextRight.gameObject.SetActive(val);
        btnNectLeft.gameObject.SetActive(val);
        btnSetting.gameObject.SetActive(val);
        btnMultiplayer.gameObject.SetActive(val);
        btnFire.gameObject.SetActive(val);
        btnRank.gameObject.SetActive(val);
        scoreRank.gameObject.SetActive(val);
    }
    public void TurnButtonInGame(bool val)
    {
        btnPause.gameObject.SetActive(val);
        gold.SetActive(val);
        score.SetActive(val);
    }
    public void CloseUIInGame()
    {
        UIManager.Instance.AnimationUI.UIOffMoveUp(UIManager.Instance.UITop.GetComponent<RectTransform>());
        UIManager.Instance.AnimationUI.UIOffMoveDown(UIManager.Instance.UIButtom.GetComponent<RectTransform>());
        UIManager.Instance.AnimationUI.UIOffMoveDown(UIManager.Instance.UIMid.GetComponent<RectTransform>());
    }
    public void OpenUIInGame()
    {
        UIManager.Instance.AnimationUI.UIOnMoveDown(UIManager.Instance.UITop.GetComponent<RectTransform>());
        UIManager.Instance.AnimationUI.UIOnMoveUp(UIManager.Instance.UIButtom.GetComponent<RectTransform>());
        UIManager.Instance.AnimationUI.UIOnMoveUp(UIManager.Instance.UIMid.GetComponent<RectTransform>());
    }
}
