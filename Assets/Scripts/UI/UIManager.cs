using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("UI")]
    [SerializeField] private UiInGameManger _uiInGameManager;
    [SerializeField] private UIBuilder _uiBuilder;
    [SerializeField] private UISetting _uiSetting;
    [SerializeField] private UISettingMusic _uiSettingMusic;

    public UiInGameManger InGameManagerUI => _uiInGameManager;
    public UIBuilder BuilderUI => _uiBuilder;
    public UISetting SettingUI => _uiSetting;
    public UISettingMusic SettingMusicUI => _uiSettingMusic;
}
