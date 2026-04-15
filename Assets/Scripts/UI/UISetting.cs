using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [Header("Button Setting")]
    [SerializeField] private Button btnDieuKhoanPhapLy;
    [SerializeField] private Button btnChinhSachQuyenRiengTu;
    [SerializeField] private Button btnCaiDat;
    [SerializeField] private Button btnTroGiupvaHoTro;
    [SerializeField] private Button btnXacSuatPhanThuong;
    [SerializeField] private Button btnQuocGia;

    [SerializeField] private Button btnBack;

    [SerializeField] private RectTransform UiShop;

    private void Awake()
    {
        btnCaiDat.onClick.AddListener(() =>
        {
            UIManager.Instance.SettingMusicUI.Open();
        });
        btnBack.onClick.AddListener(() =>
        {
            Close();
            UIManager.Instance.InGameManagerUI.OpenUIInGame();
        });
    }

    public void OnSettingMusic()
    {

    }
    
    public void Open()
    {
        UIManager.Instance.AnimationUI.UIOnMoveUp(UiShop);
    }
    public void Close()
    {
        UIManager.Instance.AnimationUI.UIOffMoveDown(UiShop);
    }

}
