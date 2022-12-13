using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChargeStateData", menuName = "Data/State Data/Charge State")]
public class ChargeStateData : ScriptableObject
{
    public float ChargeSpeed = 6f;
    public float ChargeTime = 2f;
}
