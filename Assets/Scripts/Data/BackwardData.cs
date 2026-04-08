using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Backward Data")]
public class BackwardData : ScriptableObject
{
    public float length;
    public ObjectData backward;
    public PatternData withPattern = null;
}
