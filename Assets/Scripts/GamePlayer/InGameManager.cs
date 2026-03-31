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


        PlayerController.Instance.PlayerAnim.StartRun();
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
