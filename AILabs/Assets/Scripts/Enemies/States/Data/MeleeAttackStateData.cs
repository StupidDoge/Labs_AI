using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
public class MeleeAttackStateData : ScriptableObject
{
    public float AttackRadius = 0.5f;
    public float Damage = 10f;

    public LayerMask PlayerLayer;
}
