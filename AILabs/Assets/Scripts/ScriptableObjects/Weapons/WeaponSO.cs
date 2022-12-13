using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "Data/Weapon Data/Weapon")]
public class WeaponSO : ScriptableObject
{
    public int AmountOfAttacks { get; protected set; }
    public float[] MovementSpeed { get; protected set; }
}
