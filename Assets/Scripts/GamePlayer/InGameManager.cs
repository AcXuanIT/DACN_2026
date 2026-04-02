using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum StateGame
{
    Build,Run,
}
public class InGameManager : Singleton<InGameManager>
{
    [Header("State In Game")]
    [SerializeField] private GameManager gameManager;

    [SerializeField] private CameraManager cameraManager;

    [SerializeField] private SpawnBackWard spawnBackWard;

    [SerializeField] private YardManager yardManager;


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
        PlayerController.Instance.PlayerAnim.StartRun();
        cameraManager.StartCameraToRun();

        spawnBackWard.StartSpawnBackWard();

        yardManager.StartYard();
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
