using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public enum AnimState
{
    Idle, Run , Jump , Action , Hit , Crash,
}
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

    [Header("Animation Crash")]
    [SerializeField] private AnimationClip _crashAction;
    [SerializeField] private AnimationClip _crashLoop;
    [SerializeField] private AnimationClip _crash1Action;
    [SerializeField] private AnimationClip _crash1Loop;

    [SerializeField] private AnimationClip _hitCrashAction;
    [SerializeField] private AnimationClip _hitCrashLoop;

    [Header("Animation Hit")]
    [SerializeField] private AnimationClip _hitFeet;
    [SerializeField] private AnimationClip _hitLeft;
    [SerializeField] private AnimationClip _hitRight;

    private Coroutine _currentCoroutine;
    private AnimState _animState = AnimState.Idle;

    private void Start()
    {
        PlayIdle();
    }
    //CORE
    public void Play(AnimationClip clip)
    {
        _anim.Play(clip.name);
    }

    public void PlayRoutine(IEnumerator routine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(routine);
    }

    bool CanOverride(AnimState newState)
    {
        return newState >= _animState;
    }
    
    //BASIC
    public void PlayIdle()
    {
        if (!CanOverride(AnimState.Idle)) return;

        _animState = AnimState.Idle;
        Play(_idleClip);
    }

    public void PlayRun()
    {
        if (!CanOverride(AnimState.Run)) return;

        _animState = AnimState.Run;
        Play(_runClip01);
    }
    public void PlayRunAfterJump()
    {
        if (_animState != AnimState.Jump) return;

        _animState = AnimState.Run;
        Play(_runClip01);
    }

    public void PlayRunIntro()
    {
        if (!CanOverride(AnimState.Run)) return;

        _animState = AnimState.Run;

        PlayRoutine(RunIntroRoutine());
    }

    IEnumerator RunIntroRoutine()
    {
        Play(_runIntroClip01);
        yield return new WaitForSeconds(_runIntroClip01.length);
        Play(_runClip01);
    }

    // ---------------- MOVE ----------------

    public void PlayLeft()
    {
        PlayAction(_leftClip);
    }

    public void PlayRight()
    {
        PlayAction(_rightClip);
    }

    void PlayAction(AnimationClip clip)
    {
        if (!CanOverride(AnimState.Action)) return;

        _animState = AnimState.Action;

        PlayRoutine(ActionRoutine(clip));
    }

    IEnumerator ActionRoutine(AnimationClip clip)
    {
        Play(clip);
        yield return new WaitForSeconds(clip.length);
        _animState = AnimState.Run;
        Play(_runClip01);
    }

    // ---------------- JUMP ----------------

    public void PlayJump()
    {
        if (!CanOverride(AnimState.Jump)) return;

        _animState = AnimState.Jump;
        PlayRoutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        Play(_jumpIntro);

        yield return new WaitForSeconds(_jumpIntro.length);

        Play(_jumpLoop);
    }

    public void EndJump()
    {
        _animState = AnimState.Action;
        PlayRoutine(JumpEndRoutine());
    }

    IEnumerator JumpEndRoutine()
    {
        Play(_jumpDown);
        yield return new WaitForSeconds(_jumpDown.length);

        _animState = AnimState.Run;
        Play(_runClip01);
    }

    // ---------------- DUCK ----------------

    public void PlayDuck()
    {
        PlayAction(_duckClip);
    }

    // ---------------- HIT ----------------

    public void PlayHitLeft()
    {
        PlayHit(_hitLeft);
    }

    public void PlayHitRight()
    {
        PlayHit(_hitRight);
    }

    void PlayHit(AnimationClip clip)
    {
        _animState = AnimState.Hit;
        PlayRoutine(HitRoutine(clip));
    }

    IEnumerator HitRoutine(AnimationClip clip)
    {
        Play(clip);
        yield return new WaitForSeconds(clip.length);

        _animState = AnimState.Run;
        Play(_runClip01);
    }

    // ---------------- CRASH ----------------

    public void PlayCrash()
    {
        _animState = AnimState.Crash;
        PlayRoutine(CrashRoutine());
    }

    IEnumerator CrashRoutine()
    {
        Play(_crashAction);

        yield return new WaitForSeconds(_crashAction.length);

        Play(_crashLoop);
    }
}