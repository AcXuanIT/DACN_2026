using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Data Builder")]
    public BuildData buildData;
}

[System.Serializable]
public class BuildData
{
    public List<LevelBuild> builds = new List<LevelBuild>();
}
[System.Serializable]
public class LevelBuild
{
    public int indexLevel;
}
