using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIBuilder : MonoBehaviour
{
    [Header("Button Update")]
    [SerializeField] private Button updateHouse;
    [SerializeField] private Button updatePool;

    [SerializeField] private GameObject btnUpdateHouse;
    [SerializeField] private GameObject btnUpdatePool;

    [SerializeField] private Button btnBack;

    [Header("House Items")]
    [SerializeField] private List<UIBuilderItems> houses;

    [Header("Pool Items")]
    [SerializeField] private List<UIBuilderItems> pools;

    [Header("Object UI")]
    [SerializeField] private RectTransform Uitop;
    [SerializeField] private RectTransform Uibuttom;


    private void Awake()
    {
        btnBack.onClick.AddListener(() =>
        {
            Close();
            UIManager.Instance.InGameManagerUI.OpenUIInGame();
        });
        updateHouse.onClick.AddListener(() =>
        {
            GameManager.Instance.builder.upLevel();
        });
        updatePool.onClick.AddListener(() =>
        {
            GameManager.Instance.builder.upLevelPool();
        });
    }
    private void OnEnable()
    {
        InitDataBuilder();
    }

    public void CheckLevelToSetUIHouse(int index)
    {
        if(index == 5)
        {
            updateHouse.gameObject.SetActive(false);
            return;
        }
        updateHouse.gameObject.SetActive(true);
    }
    public void CheckLevelToSetUIPool(int index)
    {
        if (index == 5)
        {
            updatePool.gameObject.SetActive(false);
            return;
        }
        updatePool.gameObject.SetActive(true);
    }

    public void InitDataBuilder()
    {
        BuildData data = GameManager.Instance.playerData.buildData;
        int houseCount = data.builds[0].indexLevel;
        int poolCount = data.builds[1].indexLevel;

        for(int i =0; i< houses.Count; i++)
        {
            if(i <  houseCount)
            {
                houses[i].TurnOn();
            }
            else
            {
                houses[i].TurnOff();
            }
        }
        for(int i=0; i< pools.Count; i++)
        {
            if(i < poolCount)
            {
                pools[i].TurnOn();
            }
            else
            {
                pools[i].TurnOff();
            }
        }
    }

    public void Open()
    {
        Debug.Log("Open UI Builder");
        UIManager.Instance.AnimationUI.UIOnMoveDown(Uitop);
        UIManager.Instance.AnimationUI.UIOnMoveUp(Uibuttom);
    }

    public void Close()
    {
        Debug.Log("Close UI Builder");
        UIManager.Instance.AnimationUI.UIOffMoveUp(Uitop);
        UIManager.Instance.AnimationUI.UIOffMoveDown(Uibuttom);
    }
}
