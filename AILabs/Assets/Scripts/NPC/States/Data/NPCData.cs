using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCData", menuName = "Data/NPC Data/Base Data")]
public class NPCData : ScriptableObject
{
    public float WallCheckDistance = 0.2f;
    public float LedgeCheckDistance = 0.4f;

    public LayerMask GroundLayer;
}
