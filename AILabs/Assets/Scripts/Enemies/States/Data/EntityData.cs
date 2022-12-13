using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Data/Entity Data/Base Data")]
public class EntityData : ScriptableObject
{
    public float MaxHealth = 10;

    public float WallCheckDistance = 0.2f;
    public float LedgeCheckDistance = 0.4f;

    public float MinAgroDistance;
    public float MaxAgroDistance;

    public float CloseRangeActionDistance = 1f;

    public LayerMask GroundLayer;
    public LayerMask PlayerLayer;
}
