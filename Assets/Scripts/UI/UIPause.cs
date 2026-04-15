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
        });
        btnGiveUp.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        btnContinue.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
