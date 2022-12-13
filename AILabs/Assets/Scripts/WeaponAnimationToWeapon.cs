using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationToWeapon : MonoBehaviour
{
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponentInParent<Weapon>();
    }

    private void AnimationFinishTrigger()
    {
        _weapon.AnimationFinishTrigger();
    }

    private void StartAnimationMovementTrigger() => _weapon.StartAnimationMovementTrigger();

    private void StopAnimationMovementTrigger() => _weapon.StopAnimationMovementTrigger();
}
