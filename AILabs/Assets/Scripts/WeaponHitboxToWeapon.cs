using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
    private AgressiveWeapon _weapon;

    private void Awake()
    {
        _weapon = GetComponentInParent<AgressiveWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
