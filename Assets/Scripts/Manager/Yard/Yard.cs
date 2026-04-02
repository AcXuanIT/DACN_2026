using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Yard : MonoBehaviour
{
    [SerializeField] private GameObject yard;

    private float speed = 2f;

    Material materialCurrent;
    Vector2 offSet;

    private void Start()
    {
        //StartOffset();
    }

    private void Update()
    {
        RunOffsetMaterialInYard();
    }

    public void StartOffset(float s)
    {
        MeshRenderer mr = yard.GetComponent<MeshRenderer>();
        materialCurrent = mr.material;
        offSet = Vector2.zero;
        speed = s ;
    }

    public void RunOffsetMaterialInYard()
    {
        if (!InGameManager.Instance.IsStartRun) return;

        offSet = offSet + new Vector2(0f, Time.deltaTime*speed);
        materialCurrent.mainTextureOffset = offSet;
    }
}
