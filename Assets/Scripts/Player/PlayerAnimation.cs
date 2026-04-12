using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animation _anim;


    [Header("List AnimationClip")]
    [SerializeField] private AnimationClip _idleClip;
    [SerializeField] private AnimationClip _idleClip02;
    [SerializeField] private AnimationClip _idleClip03;
    
    [SerializeField] private AnimationClip _runClip01;

    [SerializeField] private AnimationClip _runIntroClip01;

    [SerializeField] private AnimationClip _duckClip;

    [SerializeField] private AnimationClip _leftClip;
    [SerializeField] private AnimationClip _rightClip;
    [SerializeField] private AnimationClip _jumpLeft;
    [SerializeField] private AnimationClip _jumpRight;
    [SerializeField] private AnimationClip _jumpDown;
    [SerializeField] private AnimationClip _jumpIntro;
    [SerializeField] private AnimationClip _jumpLoop;
    [SerializeField] private AnimationClip _jumpOutro;

    private Coroutine _runCoroutine01;
    private Coroutine _runCoroutine02;
    private Coroutine _runCoroutineJump;
    private Coroutine _runCoroutineDown;
    private Coroutine _runCoroutineIdle;
    private Coroutine _runCoroutineDuck;

    private void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        _anim.Play(_idleClip.name);
        //_idleClip.wrapMode = WrapMode.Loop;
        /*foreach (AnimationState state in _anim)
        {
            Debug.Log("Tên clip: " + state.name);
            animationStates.Add(state);
        }*/
    }

    IEnumerator RunAnimationIdle()
    {
        yield return null;
    }

    public void StartRunAnim()
    {
        _runCoroutine01 = StartCoroutine(StartDelay(_runIntroClip01, _runClip01));
    }

    public void StartDuck()
    {
        _runCoroutineDuck = StartCoroutine(StartDelayToRun(_duckClip));
    }
    public void StartLeftRight(int dir)
    {
        if(dir == 1)
        {
            _runCoroutine02 = StartCoroutine(StartDelayToRun(_rightClip));
        }
        else if(dir == -1)
        {
            _runCoroutine02 = StartCoroutine(StartDelayToRun(_leftClip));
        }
    }
    public void StartJump()
    {
        _runCoroutineJump = StartCoroutine(StartJumpDelayToRun());
    }
    public void StartRunTrigger()
    {
        StartCoroutine(StartJumpToRun());
    }
    
    public void StartJumpLeftRight(int dir)
    {
        if(dir == 1)
        {
            _runCoroutine02 = StartCoroutine(StartDelay(_jumpRight, _runClip01));
        }
        else if(dir == -1)
        {
            _runCoroutine02 = StartCoroutine(StartDelay(_jumpLeft, _runClip01));
        }
    }
    public void StartDown()
    {
        _runCoroutineDown = StartCoroutine(StartDelayToRun(_jumpDown));
    }

    IEnumerator StartDelayToRun(AnimationClip clip)
    {
        yield return StartDelay(clip, _runClip01);
        PlayerController.Instance.PlayerCol.SetActiveCollider(true);
    }

    IEnumerator StartDelay(AnimationClip clip, AnimationClip clip2)
    {
        _anim.Play(clip.name);

        yield return new WaitForSeconds(clip.length);

        _anim.Play(clip2.name);
    }
    IEnumerator StartJumpDelayToRun()
    {
        _anim.Play(_jumpIntro.name);
        yield return new WaitForSeconds(_jumpIntro.length);
        _anim.Play(_jumpLoop.name);
        /*yield return new WaitForSeconds(_jumpLoop.length);
        _anim.Play(_jumpOutro.name);
        yield return new WaitForSeconds(_jumpOutro.length);
        _anim.Play(_runClip01.name);*/
    }

    IEnumerator StartJumpToRun()
    {
        _anim.Play(_jumpOutro.name);

        yield return new WaitForSeconds(_jumpOutro.length);

        _anim.Play(_runClip01.name);
    }
}
