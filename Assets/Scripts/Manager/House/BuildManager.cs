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
        _houseAnimation.level = GameManager.Instance.playerData.buildData.builds[0].indexLevel;
        _poolAnimation.level = GameManager.Instance.playerData.buildData.builds[1].indexLevel;
    }

    public void upLevel()
    {
        _houseAnimation.level++;
        if(_houseAnimation.level > 5 ) _houseAnimation.level=5;
        GameManager.Instance.playerData.buildData.builds[0].indexLevel  = _houseAnimation.level;
        UIManager.Instance.BuilderUI.CheckLevelToSetUIHouse(_houseAnimation.level);
        UIManager.Instance.BuilderUI.InitDataBuilder();
        _houseAnimation.StartLevel();
    }
    public void upLevelPool()
    {
        _poolAnimation.level++;
        if (_poolAnimation.level > 5) _poolAnimation.level = 5;
        GameManager.Instance.playerData.buildData.builds[1].indexLevel = _poolAnimation.level;
        UIManager.Instance.BuilderUI.CheckLevelToSetUIPool(_poolAnimation.level);
        UIManager.Instance.BuilderUI.InitDataBuilder();
        _poolAnimation.StartLevel();
    }
}
