using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRank : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btnBack;

    [Header("Object UI")]
    [SerializeField] private RectTransform UiRank;

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
        UIManager.Instance.AnimationUI.UIOnMoveUp(UiRank);
    }
    public void Close()
    {
        UIManager.Instance.AnimationUI.UIOffMoveDown(UiRank);

    }
}
