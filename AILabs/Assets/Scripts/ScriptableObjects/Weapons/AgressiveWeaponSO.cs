using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgressiveWeaponSO", menuName = "Data/Weapon Data/Agressive Weapon")]
public class AgressiveWeaponSO : WeaponSO
{
    [SerializeField] private WeaponAttackDetails[] _attackDetails;

    public WeaponAttackDetails[] AttackDetails { get => _attackDetails; set => _attackDetails = value; }

    private void OnEnable()
    {
        AmountOfAttacks = _attackDetails.Length;
        MovementSpeed = new float[AmountOfAttacks];

        for (int i = 0; i < AmountOfAttacks; i++)
            MovementSpeed[i] = _attackDetails[i].MovementSpeed;
    }
}
