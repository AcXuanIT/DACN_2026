using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [Header("Object UI")]
    [SerializeField] private RectTransform UiInGame;

    [Header("Button In Game")]
    [SerializeField] private Button btnPause;
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject score;

    private void Awake()
    {
        btnPause.onClick.AddListener(() =>
        {
            UIManager.Instance.PauseUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
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
