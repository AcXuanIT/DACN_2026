using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UITop : MonoBehaviour
{
    [Header("Button Top")]
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnMultiplayer;
    [SerializeField] private Button btnFire;
    [SerializeField] private Button btnRank;
    [SerializeField] private GameObject scoreRank;

    private void Awake()
    {
        btnSetting.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUIMainGame();
            UIManager.Instance.SettingUI.Open();
        });

        btnRank.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUIMainGame();
            UIManager.Instance.RankUI.Open();
        });
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
        gameObject.SetActive(val);
    }
    public void OpenUITop()
    {
        UIManager.Instance.AnimationUI.UIOnMoveDown(gameObject.GetComponent<RectTransform>());
    }
    public void CloseUITop()
    {
        UIManager.Instance.AnimationUI.UIOffMoveUp(gameObject.GetComponent<RectTransform>());
    }
    
}
