using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackWard : MonoBehaviour
{
    [Header("Data Backwards")]
    [SerializeField] private List<BackwardData> backwards = new List<BackwardData>();

    [Header("Tranform")]
    [SerializeField] private Transform parentBackWard;

    private float lengthCheck = 0f;


    public float LengthCheck
    {
        get { return lengthCheck; }
        set { lengthCheck = value; }
    }

    void Start()
    {
        //StartSpawnBackWard();
    }


    void Update()
    {
        //SpawnBackWardObject();
    }

    public BackwardData RandomBackWard()
    {
        int rd = Random.Range(0, backwards.Count);
        return backwards[rd];
    }

    public void SpawnBackward(BackwardData backward, Transform parent)
    {
        GameObject newBw = PoolingManager.Spawn(backward.backward.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        newBw.transform.SetParent(parent, false);
    }
}
