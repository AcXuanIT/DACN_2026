using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        RotationStars();
    }

    public void RotationStars()
    {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
