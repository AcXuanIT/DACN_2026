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

    private void Awake()
    {
        btnPlayGame.onClick.AddListener(() =>
        {
            Debug.Log("On Click Button Play Game");

            InGameManager.Instance.StartGame();
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
    }
}
