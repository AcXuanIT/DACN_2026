using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animation _anim;


    [Header("List AnimationClip")]
    [SerializeField] private List<AnimationState> animationStates = new List<AnimationState>();

    [SerializeField] private AnimationClip _idleClip;
    
    [SerializeField] private AnimationClip _runClip01;

    [SerializeField] private AnimationClip _runIntroClip01;



    private Coroutine _runCoroutine01;

    private void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        _anim.Play(_idleClip.name);

        foreach (AnimationState state in _anim)
        {
            Debug.Log("Tên clip: " + state.name);
            animationStates.Add(state);
        }
    }

    public void StartRun()
    {
        _runCoroutine01 = StartCoroutine(StartIntroRunToRun());
    }

    IEnumerator StartIntroRunToRun()
    {
        _anim.Play(_runIntroClip01.name);

        yield return new WaitForSeconds(_runIntroClip01.length);

        _anim.Play(_runClip01.name);
    }
}
