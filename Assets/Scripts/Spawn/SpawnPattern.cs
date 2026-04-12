using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour
{
    [Header("Tranform Postion")]
    [SerializeField] private Transform posLeft;
    [SerializeField] private Transform posMid;
    [SerializeField] private Transform posRight;

    [Header("List Spawn Pattern")]
    [SerializeField] private List<PatternData> patternDatas;

    [Header("Lane")]
    [SerializeField] private PatternData patternCurrent;

    [Header("Prefabs new Object")]
    [SerializeField] private GameObject prefabObj;

    private int indexSpawn = 0;
    [Header("Special Pattern")]
    [SerializeField] private PatternData _patternData01;
   

    public PatternData RandomPatternData(float lenghth)
    {
        indexSpawn++;
        if(indexSpawn == 1 ||  indexSpawn == 2)
        {
            return _patternData01;
        }

        int patternIndex = Random.Range(0, patternDatas.Count);

        PatternData patternData = patternDatas[patternIndex];

        while(patternData.length != lenghth)
        {
            patternIndex = Random.Range(0, patternDatas.Count);
            patternData = patternDatas[patternIndex];
        }

        if(patternData == null) return null;

        if (patternCurrent != null)
        {
            if (CheckLaneFree(patternCurrent.endFreeLane, patternData.startFreeLane))
            {
                patternCurrent = patternData;
                return patternData;
            }
        }
        else if (patternCurrent == null)
        {
            if(CheckLaneFree(new List<bool> { true,true,true}, patternData.startFreeLane))
            {
                patternCurrent = patternData;
                return patternData;
            }
        }

        return null;
    }
    public bool CheckLaneFree(List<bool> currentLane,  List<bool> newLane)
    {
        if (currentLane[0] && newLane[0]) return true;
        if (currentLane[1] && newLane[1]) return true;
        if (currentLane[2] && newLane[2]) return true;

        return false;
    }
    public List<PatternData> RandomPatternWithLength(float length)
    {
        if (length == 10f)
        {
            return new List<PatternData> { RandomPatternData(10f) };
        }
        else if(length == 30f)
        {
            List<PatternData> list = new List<PatternData>();

            list.Add(RandomPatternData(10f));
            list.Add(RandomPatternData(10f));
            list.Add(RandomPatternData(10f));

            return list;
        }

        return null;
    }

    public void SpawnPatternObject(List<PatternData> patternsData, Transform pa)
    {
        float length = 0f;
        foreach(PatternData patternData in patternsData)
        {
            GameObject newObj = PoolingManager.Spawn(prefabObj, new Vector3(0f, 0f, length), Quaternion.identity);
            newObj.transform.SetParent(pa, false);
            length += patternData.length;

            if (patternData.patterns == null) continue;

            foreach(SpawnData spawnData in patternData.patterns)
            {
                GameObject obj = PoolingManager.Spawn(spawnData.objectData.prefab, spawnData.spawnPosition, Quaternion.identity);
                obj.transform.SetParent(newObj.transform, false);
            }
        }
    }
}
