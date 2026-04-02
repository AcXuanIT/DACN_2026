using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YardManager : MonoBehaviour
{
    [SerializeField] private List<Yard> yards = new List<Yard>();

    public void StartYard()
    {
        foreach (Yard yard in yards)
        {
            yard.StartOffset(InGameManager.Instance.SpeedGame);
        }
    }
}
