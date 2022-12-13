using UnityEngine;

public struct AttackDetails
{
    public Vector2 position;
    public float damageAmount;
}

[System.Serializable]
public struct WeaponAttackDetails
{
    public string AttackName;
    public float MovementSpeed;
    public float DamageAmount;
    public AudioClip AttackSound;
}
