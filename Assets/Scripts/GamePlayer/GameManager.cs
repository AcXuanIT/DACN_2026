using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player Data")]
    [SerializeField] private PlayerData _playerData;


    public PlayerData playerData => _playerData;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
