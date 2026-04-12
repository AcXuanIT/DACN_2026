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

    //Kiem sat spawn backward
    private int backwardIndex = 0;


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
        backwardIndex++;
        int rd = Random.Range(0, backwards.Count);
        BackwardData backward = backwards[rd];

        while(backwardIndex  <=4 && backward.withPattern != null)
        {
            rd = Random.Range(0, backwards.Count);
            backward = backwards[rd];
        }

        return backward;
    }

    public void SpawnBackward(BackwardData backward, Transform parent)
    {
        GameObject newBw = PoolingManager.Spawn(backward.backward.prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        newBw.transform.SetParent(parent, false);
    }
}
