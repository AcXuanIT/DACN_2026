using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player Data")]
    [SerializeField] private PlayerData _playerData;

    [Header("Manager")]
    [SerializeField] private BuildManager _builderManager;

    public PlayerData playerData => _playerData;
    public BuildManager builder => _builderManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
