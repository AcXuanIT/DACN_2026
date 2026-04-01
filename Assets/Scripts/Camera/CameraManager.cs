using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animation _animCamera;
    [SerializeField] private AnimationClip _startRunClip;



    public void StartCameraToRun()
    {
        _animCamera.Play(_startRunClip.name);
    }
}
