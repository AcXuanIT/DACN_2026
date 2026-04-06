using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [Header("Tranform Postion")]
    [SerializeField] private Transform posLeft;
    [SerializeField] private Transform posMid;
    [SerializeField] private Transform posRight;

    [Header("List Spawn Items")]
    [SerializeField] private List<GameObject> items = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawn()
    {

    }

    public void SpawnItems()
    {
        if (!InGameManager.Instance.IsStartRun) return;
        
    }

    public void RandomPattern()
    {

    }
}
