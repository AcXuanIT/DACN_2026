using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [Header("Collider")]
    [SerializeField] private Collider colliderCheckGround;

    private void Start()
    {
        SetActiveCollider(false);
    }


    public void SetActiveCollider(bool val)
    {
        colliderCheckGround.enabled = val;
    }
}
