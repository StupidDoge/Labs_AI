using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCIdleStateData", menuName = "NPC Data/State Data/Idle State")]
public class NPCIdleStateData : ScriptableObject
{
    public float MinIdleTime = 1f;
    public float MaxIdleTime = 2f;
}
