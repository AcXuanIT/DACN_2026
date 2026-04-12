using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuilder : MonoBehaviour
{
    [Header("Button Update")]
    [SerializeField] private Button updateHouse;
    [SerializeField] private Button updatePool;

    [SerializeField] private Button btnBack;


    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
