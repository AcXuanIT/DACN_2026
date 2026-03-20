using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    private Vector3 targetPos;

    void Update()
    {
        if (IsOwner)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, 0, z);
            transform.Translate(move * speed * Time.deltaTime);

            SendPositionServerRpc(transform.position);
        }
        else
        {
            // smooth
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
        }
    }

    [ServerRpc]
    void SendPositionServerRpc(Vector3 pos)
    {
        UpdatePositionClientRpc(pos);
    }

    [ClientRpc]
    void UpdatePositionClientRpc(Vector3 pos)
    {
        if (IsOwner) return;
        targetPos = pos;
    }
}