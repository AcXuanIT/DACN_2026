using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInGameManger : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button btnPlayGame;

    private void Awake()
    {
        btnPlayGame.onClick.AddListener(() =>
        {
            Debug.Log("On Click Button Play Game");
            InGameManager.Instance.StartGame();
        });
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
