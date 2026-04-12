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

    private void Awake()
    {
        btnCaiDat.onClick.AddListener(() =>
        {
            UIManager.Instance.SettingMusicUI.gameObject.SetActive(true);
        });
        btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void OnSettingMusic()
    {

    }

}
