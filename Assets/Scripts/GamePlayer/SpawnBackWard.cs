using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackWard : MonoBehaviour
{
    [SerializeField] private Transform parentBackWard;
    
    [SerializeField] private List<GameObject> listPrefabs = new List<GameObject>();

    private List<GameObject> list = new List<GameObject>();

    private GameObject backWardCurrent;
    private float backWardCurrentIndex;

    private bool IsStartSpawn = false;

    void Start()
    {
        //StartSpawnBackWard();
    }


    void Update()
    {
        SpawnBackWardObject();
    }
    public void StartSpawnBackWard()
    {
        Debug.Log("Start Spawn");

        float lengthStart = 0;

        while (lengthStart <= 100)
        {
            //Debug.Log(lengthStart);
            int randomBW = RandomBackWard();
            backWardCurrent = PoolingManager.Spawn(listPrefabs[randomBW], new Vector3(0f,0f,lengthStart), Quaternion.identity, parentBackWard);
            MoveObject moveO = backWardCurrent.GetComponent<MoveObject>();
            moveO.Init(InGameManager.Instance.SpeedGame);
            list.Add(backWardCurrent);
            backWardCurrentIndex = backWardCurrent.GetComponent<Renderer>().bounds.size.z;
            lengthStart += backWardCurrentIndex;
        }

        IsStartSpawn = true;
    }
    public void SpawnBackWardObj(int index)
    {
        backWardCurrent = PoolingManager.Spawn(listPrefabs[index], new Vector3(0f, 0f, 100), Quaternion.identity, parentBackWard);
        MoveObject moveO = backWardCurrent.GetComponent<MoveObject>();
        moveO.Init(InGameManager.Instance.SpeedGame);
        list.Add(backWardCurrent);
        backWardCurrentIndex = backWardCurrent.GetComponent<Renderer>().bounds.size.z;
    }

    public void SpawnBackWardObject()
    {
        if (!IsStartSpawn) return;

        if(CheckCurrentBackWard())
        {
            SpawnBackWardObj(RandomBackWard());
        }    
    }
    public bool CheckCurrentBackWard()
    {
        bool isCheck = false;

        if(backWardCurrent.transform.position.z <= 100 - backWardCurrentIndex)
            isCheck = true;

        return isCheck;
    }
    public int RandomBackWard()
    {
        return Random.Range(0, listPrefabs.Count);
    }
}
