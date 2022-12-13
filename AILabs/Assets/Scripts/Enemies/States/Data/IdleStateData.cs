using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleStateData", menuName = "Data/State Data/Idle State")]
public class IdleStateData : ScriptableObject
{
    public float MinIdleTime = 1f;
    public float MaxIdleTime = 2f;
    
}
