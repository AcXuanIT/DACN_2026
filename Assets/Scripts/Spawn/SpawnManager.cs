 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SpawnManager : Singleton<SpawnManager>
{
    [Header("Spawn")]
    [SerializeField] private SpawnBackWard spawnBackWard;
    [SerializeField] private SpawnPattern spawnPattern;

    [Header("State")]
    [SerializeField] private float maxPosSpawn = 100f;

    [SerializeField] private List<MoveObject> listObject = new List<MoveObject>();
    [SerializeField] private Transform parent;
    [SerializeField] private MoveObject moveObject;
    [SerializeField] private GameObject current;
    private float lengthCheck = 0f;

    public SpawnBackWard SpawnBackWard => spawnBackWard;
    public SpawnPattern SpawnPattern => spawnPattern;   
    public float MaxPosSpawn => maxPosSpawn;    


    private void Update()
    {
        ProcessingSpawn();
    }
    public void StartSpawn()
    {
        Debug.Log("Spawn Pattern");

        float lengthStart = 0f;

        while(lengthStart <= maxPosSpawn)
        {
            float length = RandomSpawn(lengthStart);
            lengthStart += length;
        }
    }

    public void ProcessingSpawn()
    {
        if (!InGameManager.Instance.IsStartRun) return;
        if(current == null) return;

        if(current.transform.position.z <= MaxPosSpawn - lengthCheck)
        {
            lengthCheck = RandomSpawn(MaxPosSpawn);
        }
    }

    public float RandomSpawn(float posZ)
    {
        BackwardData randomBackward = spawnBackWard.RandomBackWard();

        if(randomBackward == null)
        {
            Debug.Log("Random Backward is null");
        }

        MoveObject newObj = PoolingManager.Spawn(moveObject, new Vector3(0f, 0f, posZ), Quaternion.identity, parent);

        listObject.Add(newObj);
        current = newObj.gameObject;

        float lengthBackward = randomBackward.length;
        lengthCheck = lengthBackward;

        if (randomBackward.withPattern != null)
        {
            PatternData pattern = randomBackward.withPattern;
            //Spawn
            SpawnWithData(randomBackward, new List<PatternData>{ pattern}, newObj.transform);
        }
        else
        {
            List<PatternData> patterns = new List<PatternData>();
            patterns = spawnPattern.RandomPatternWithLength(lengthBackward);
            //Spawn
            SpawnWithData(randomBackward, patterns, newObj.transform);
        }

        return lengthBackward;
    }

    public void SpawnWithData(BackwardData backwardData, List<PatternData> patterns, Transform pa)
    {
        spawnBackWard.SpawnBackward(backwardData, pa);
        spawnPattern.SpawnPatternObject(patterns, pa);
    }
}
