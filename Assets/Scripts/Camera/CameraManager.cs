using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public enum ActionCamera
{
    LeftRight,
}
public class CameraManager : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animation _animCamera;
    [SerializeField] private AnimationClip _startRunClip;

    private int indexCamera = 0;

    private void OnEnable()
    {
        ObserverManager<ActionCamera>.AddDesgisterEvent(ActionCamera.LeftRight, FollowPlayer);
    }
    private void OnDisable()
    {
        ObserverManager<ActionCamera>.RemoveAddListener(ActionCamera.LeftRight, FollowPlayer);
    }

    public void StartCameraToRun()
    {
        _animCamera.Play(_startRunClip.name);
    }
    
    public void FollowPlayer(object dir)
    {
        Vector3 movePos = transform.position;
        indexCamera += (int)dir;
        movePos.x += (int)dir * 0.6f;

        transform.DOMove(movePos, 0.25f).OnComplete(() =>
        {
            Vector3 pos = transform.position;
            if (indexCamera == 1) pos.x = 0.6f;
            else if (indexCamera == 0) pos.x = 0f;
            else if (indexCamera == -1) pos.x = -0.6f;
            transform.position = pos;
        });
    }
}
