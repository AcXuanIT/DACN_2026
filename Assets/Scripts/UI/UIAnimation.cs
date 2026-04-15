using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class UIAnimation : MonoBehaviour
{
    private Dictionary<RectTransform, Tween> tweenDict = new Dictionary<RectTransform, Tween>();
    [SerializeField] private float dura;

    public void UIOnMoveUp(RectTransform ui)
    {
        UIOnMoveUp(ui, dura);
    }

    public void UIOnMoveUp(RectTransform ui, float duration)
    {
        KillTween(ui);

        Vector2 target = ui.anchoredPosition;
        Vector2 start = target - new Vector2(0, GetHeight(ui));

        ui.anchoredPosition = start;
        ui.gameObject.SetActive(true);

        Tween t = ui.DOAnchorPos(target, duration).SetEase(Ease.OutCubic);
        tweenDict[ui] = t;
    }
    public void UIOnMoveDown(RectTransform ui)
    {
        UIOnMoveDown(ui, dura);
    }

    public void UIOnMoveDown(RectTransform ui, float duration)
    {
        KillTween(ui);

        Vector2 target = ui.anchoredPosition;
        Vector2 start = target + new Vector2(0, GetHeight(ui));

        ui.anchoredPosition = start;
        ui.gameObject.SetActive(true);

        Tween t = ui.DOAnchorPos(target, duration).SetEase(Ease.OutCubic);
        tweenDict[ui] = t;
    }
    public void UIOffMoveUp(RectTransform ui)
    {
        UIOffMoveUp (ui, dura);
    }

    public void UIOffMoveUp(RectTransform ui, float duration)
    {
        KillTween(ui);

        Vector2 start = ui.anchoredPosition;
        Vector2 target = start + new Vector2(0, GetHeight(ui));

        Tween t = ui.DOAnchorPos(target, duration)
            .SetEase(Ease.InCubic)
            .OnComplete(() => { 
                ui.gameObject.SetActive(false);
                ui.anchoredPosition = start;
            });

        tweenDict[ui] = t;
    }
    public void UIOffMoveDown(RectTransform ui)
    {
        UIOffMoveDown (ui, dura);
    }

    public void UIOffMoveDown(RectTransform ui, float duration)
    {
        KillTween(ui);

        Vector2 start = ui.anchoredPosition;       
        Vector2 target = start - new Vector2(0, GetHeight(ui));

        Tween t = ui.DOAnchorPos(target, duration)
            .SetEase(Ease.InCubic)
            .OnComplete(() => {
                ui.gameObject.SetActive(false);
                ui.anchoredPosition = start;
                }); 

        tweenDict[ui] = t;
    }

    private void KillTween(RectTransform ui)
    {
        if (tweenDict.ContainsKey(ui) && tweenDict[ui] != null && tweenDict[ui].IsActive())
        {
            tweenDict[ui].Kill();
        }
    }

    private float GetHeight(RectTransform ui)
    {
        return ui.rect.height;
    }
}