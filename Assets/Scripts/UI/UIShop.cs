using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button btnBack;

    [Header("UI object")]
    [SerializeField] private RectTransform Uishop;

    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            Close();
            UIManager.Instance.InGameManagerUI.OpenUIInGame();
        });
    }

    public void Open()
    {
        UIManager.Instance.AnimationUI.UIOnMoveUp(Uishop);
    }
    public void Close()
    {
        UIManager.Instance.AnimationUI.UIOffMoveDown(Uishop);
    }
}
