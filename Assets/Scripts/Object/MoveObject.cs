using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float speed = 5f;

    private void Update()
    {
        Move();

        Delete();
    }
    public void Init(float s)
    {
        speed = s;
    }

    public void Move()
    {
        if (!InGameManager.Instance.IsStartRun) return;

        transform.Translate(Vector3.back *  speed * Time.deltaTime);
    }
    public void Delete()
    { 
        if(transform.position.z <= -30)
        {
            Destroy(gameObject); 
        }
    }
}
