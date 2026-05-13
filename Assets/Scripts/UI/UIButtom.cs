using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIButtom : MonoBehaviour
{
    [Header("Button Buttom")]
    [SerializeField] private Button btnPlayGame;
    [SerializeField] private Button btnBuilder;
    [SerializeField] private Button btnShop;

    private void Awake()
    {
        //Bottom
        btnPlayGame.onClick.AddListener(() =>
        {
            Debug.Log("On Click Button Play Game");

            InGameManager.Instance.StartGame();
            UIManager.Instance.CloseUIMainGame();

            DOVirtual.DelayedCall(1f, () =>
            {

                DOVirtual.DelayedCall(1.2f, () => {
                    UIManager.Instance.GameUI.Open();
                });
            });

        });
        btnBuilder.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUIMainGame();
            UIManager.Instance.BuilderUI.Open();
        });
        btnShop.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUIMainGame();
            UIManager.Instance.ShopUI.Open();
        });
    }

    public void SetActiveButtom(bool val)
    {
        gameObject.SetActive(val);
    }
    public void OpenUIButtom()
    { 
        UIManager.Instance.AnimationUI.UIOnMoveUp(gameObject.GetComponent<RectTransform>());
    }
    public void CloseUIButtom()
    {
        UIManager.Instance.AnimationUI.UIOffMoveDown(gameObject.GetComponent<RectTransform>());
    }
    
}
