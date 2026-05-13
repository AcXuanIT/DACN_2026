using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnGiveUp;
    [SerializeField] private Button btnContinue;

    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            DelayTimeScale();
        });
        btnGiveUp.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            DelayTimeScale();
        });
        btnContinue.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            DelayTimeScale();
        });
    }

    public void DelayTimeScale()
    {
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 1.5f)
        .SetEase(Ease.OutQuad)
        .SetUpdate(true);
    }
}
