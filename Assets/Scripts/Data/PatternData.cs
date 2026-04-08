using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern", menuName = "PatternData")]
public class PatternData : ScriptableObject
{
    public float length;

    public List<SpawnData> patterns;

    public List<bool> startFreeLane = new List<bool>{true, true, true};
    public List<bool> endFreeLane = new List<bool> { true, true, true };
}

[System.Serializable]
public class SpawnData
{
    public ObjectData objectData;

    public Vector3 spawnPosition;
}


