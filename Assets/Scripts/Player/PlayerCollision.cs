using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitX
{ 
    Left, Right, Mid, None,
}
public enum HitY
{
    Up, Down, Mid,Low, None,
}
public enum HitZ
{
    Foward, Back, Mid, None,
}
public class PlayerCollision : MonoBehaviour
{
    public HitX hitX = HitX.None;
    public HitY hitY = HitY.None;
    public HitZ hitZ = HitZ.None;

    public void OnPlayerColliderHit(Collider collider)
    {
        hitX = GetHitX(collider);
        hitY = GetHitY(collider);
        hitZ = GetHitZ(collider);

        if(hitX == HitX.Mid && hitZ == HitZ.Foward)
        {
            if(hitY == HitY.Low)
            {

            }
            else
            {
                PlayerController.Instance.PlayerAnim.PlayCrash();
                InGameManager.Instance.EndGame();
            }
        }
        else if(hitZ == HitZ.Mid)
        {
            if (hitX == HitX.Left)
            {
                Debug.Log("Hit Left");
                PlayerController.Instance.PlayerMovement.MoveLR(Direction.Left);
                PlayerController.Instance.PlayerAnim.PlayHitLeft();
            }
            else if(hitX == HitX.Right)
            {
                Debug.Log("Hit Right");
                PlayerController.Instance.PlayerMovement.MoveLR(Direction.Right);
                PlayerController.Instance.PlayerAnim.PlayHitRight();
            }
        }

        //ResetHit();
    }
    public HitX GetHitX(Collider col)
    {
        Bounds bounds_Player = PlayerController.Instance.PlayerCol.ColliderPlayer.bounds;
        Bounds bounds_Col = col.bounds;

        float minX = Mathf.Max(bounds_Col.min.x, bounds_Player.min.x);
        float maxX = Mathf.Min(bounds_Col.max.x, bounds_Player.max.x);

        float average = (minX + maxX)  / 2f  - bounds_Col.min.x;

        HitX hit;

        if(average > 0.66f)
        {
            hit = HitX.Right;
        }
        else if(average < 0.33f)
        {
            hit = HitX.Left;
        }
        else
        {
            hit = HitX.Mid;
        }

        return hit;
    }

    public HitY GetHitY(Collider col)
    {
        Bounds bounds_Player = PlayerController.Instance.PlayerCol.ColliderPlayer.bounds;
        Bounds bounds_Col = col.bounds;

        float minY = Mathf.Max(bounds_Col.min.y, bounds_Player.min.y);
        float maxY = Mathf.Min(bounds_Col.max.y, bounds_Player.max.y);

        float average = ((minY + maxY) / 2f - bounds_Player.min.y)/bounds_Player.size.y;

        HitY hit;

        if(average < 0.17f)
        {
            hit = HitY.Low;
        }
        else if (average <0.33f)
        {
            hit = HitY.Down;
        }
        else if (average < 0.66f)
        {
            hit = HitY.Mid;
        }
        else
        {
            hit = HitY.Up;
        }

        return hit;
    }

    public HitZ GetHitZ(Collider col)
    {
        Bounds bounds_Player = PlayerController.Instance.PlayerCol.ColliderPlayer.bounds;
        Bounds bounds_Col = col.bounds;

        float minZ = Mathf.Max(bounds_Col.min.z, bounds_Player.min.z);
        float maxZ = Mathf.Min(bounds_Col.max.z, bounds_Player.max.z);

        float average = ((minZ + maxZ) / 2f - bounds_Player.min.z) / bounds_Player.size.z;

        HitZ hit;

        if (average < 0.33f)
        {
            hit = HitZ.Back;
        }
        else if (average < 0.66f)
        {
            hit = HitZ.Mid;
        }
        else
        {
            hit = HitZ.Foward;
        }

        return hit;
    }

    public void ResetHit()
    {
        hitX = HitX.None;
        hitY = HitY.None;
        hitZ = HitZ.None;
    }

}
