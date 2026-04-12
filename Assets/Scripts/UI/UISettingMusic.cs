using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingMusic : MonoBehaviour
{
    [Header("Button Sound ")]
    [SerializeField] private Button btnMusic;
    [SerializeField] private Button btnSoundVFX;
    [SerializeField] private Button btnSoundNotifi;

    [SerializeField] private Button btnBack;

    [Header("Image Tick Volume")]
    [SerializeField] private Image imgMusic;
    [SerializeField] private Image imgSoundVFX;
    [SerializeField] private Image imgSoundNotifi;

    [Header("Data")]
    [SerializeField] private SoundVolumeData _volumeData;

    private void Awake()
    {
        btnMusic.onClick.AddListener(() =>
        {
            ClickButtonVolumeMusic(_volumeData.volumeMusic, imgMusic);
        });
        btnSoundVFX.onClick.AddListener(() =>
        {
            ClickButtonVolumeSoundVFX(_volumeData.volumeSoundVFX, imgSoundVFX);
        });
        btnSoundNotifi.onClick.AddListener(() =>
        {
            ClickButtonVolumeSoundNotifi(_volumeData.volumeSoundNotifi, imgSoundNotifi);
        });
        btnBack.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
    private void OnEnable()
    {
        InitVolume();
    }

    public void InitVolume()
    {
        if (_volumeData == null) return;

        SetVolume(_volumeData.volumeMusic, imgMusic);
        SetVolume(_volumeData.volumeSoundVFX, imgSoundVFX);
        SetVolume(_volumeData.volumeSoundNotifi, imgSoundNotifi);
    }

    public void SetVolume(bool val , Image img)
    {
        if(val)
            img.enabled = true;
        else
            img.enabled = false;
    }

    public void ClickButtonVolumeMusic(bool val, Image img)
    {
        val = !val;
        SetVolume(val, img);
        _volumeData.volumeMusic = val;
    }
    public void ClickButtonVolumeSoundVFX(bool val, Image img)
    {
        val = !val;
        SetVolume(val, img);
        _volumeData.volumeSoundVFX = val;
    }
    public void ClickButtonVolumeSoundNotifi(bool val, Image img)
    {
        val = !val;
        SetVolume(val, img);
        _volumeData.volumeSoundNotifi = val;
    }
}
