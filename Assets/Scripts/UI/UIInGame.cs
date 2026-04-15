using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btnPause;

    [Header("Object UI")]
    [SerializeField] private RectTransform UiInGame;
    private void Awake()
    {
        btnPause.onClick.AddListener(() =>
        {
            UIManager.Instance.PauseUI.gameObject.SetActive(true);
        });
    }

    public void Open()
    {
        UIManager.Instance.AnimationUI.UIOnMoveDown(UiInGame);
    }
    public void Close()
    {
        UIManager.Instance.AnimationUI.UIOffMoveUp(UiInGame);

    }
}
