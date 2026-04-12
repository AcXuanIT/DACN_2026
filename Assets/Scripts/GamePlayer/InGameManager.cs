using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum StateGame
{
    Build,Run,End,
}
public class InGameManager : Singleton<InGameManager>
{
    [Header("State In Game")]
    [SerializeField] private GameManager gameManager;

    [SerializeField] private CameraManager cameraManager;

    [SerializeField] private YardManager yardManager;

    [SerializeField] private SpawnManager spawnManager;


    [Header("State")]
    [SerializeField] private float speedGame = 4f;

    [SerializeField] private bool isStartRun = false;
    public float SpeedGame => speedGame;
    public bool IsStartRun => isStartRun;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        Debug.Log("Start Game");

        isStartRun = true;
        PlayerController.Instance.PlayerAnim.StartRunAnim();

        //spawnBackWard.StartSpawnBackWard();

        DOVirtual.DelayedCall(0.7f, () =>
        {
            cameraManager.StartCameraToRun();
            spawnManager.StartSpawn();
        });

        //yardManager.StartYard();
    }
    public void EndGame()
    {

    }

    public void GoBack()
    {

    }
    public void NextGame()
    {

    }
    public void PauseGame()
    {

    }
    public void ContinueGame()
    {

    }
}
