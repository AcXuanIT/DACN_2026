using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private BuildAnimation _houseAnimation;
    [SerializeField] private BuildAnimation _poolAnimation;

    [SerializeField] private Button btnUp;
    [SerializeField] private Button btnDown;
    [SerializeField] private Button btnUp1;
    [SerializeField] private Button btnDown1;

    private void Awake()
    {
        btnUp.onClick.AddListener(() =>
        {
            upLevel();
        });
        btnDown.onClick.AddListener(() =>
        {
            DownLevel();
        });
        btnUp1.onClick.AddListener(() =>
        {
            upLevelPool();
        });
        btnDown1.onClick.AddListener(() =>
        {
            DownLevelPool();
        });
    }

    public void upLevel()
    {
        _houseAnimation.level++;
        if(_houseAnimation.level > 5 ) _houseAnimation.level=5;
        _houseAnimation.StartLevel();
    }
    public void DownLevel()
    {
       _houseAnimation.level--;
        if(_houseAnimation.level < 1) _houseAnimation.level = 1;
        _houseAnimation.StartLevel();
    }
    public void upLevelPool()
    {
        _poolAnimation.level++;
        if (_poolAnimation.level > 5) _poolAnimation.level = 5;
        _poolAnimation.StartLevel();
    }
    public void DownLevelPool()
    {
        _poolAnimation.level--;
        if (_poolAnimation.level < 1) _poolAnimation.level = 1;
        _poolAnimation.StartLevel();
    }

}
