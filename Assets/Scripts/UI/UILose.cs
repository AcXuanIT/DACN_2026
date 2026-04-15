using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILose : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
