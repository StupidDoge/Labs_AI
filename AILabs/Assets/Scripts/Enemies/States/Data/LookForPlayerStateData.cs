using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LookForPlayerStateData", menuName = "Data/State Data/Look For Player State")]
public class LookForPlayerStateData : ScriptableObject
{
    public int AmountOfTurns = 2;
    public float TimeBetweenTurns = 0.5f;
}
