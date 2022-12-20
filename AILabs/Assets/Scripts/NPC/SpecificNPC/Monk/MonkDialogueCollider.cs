using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkDialogueCollider : MonoBehaviour
{
    private Monk _monk;

    private void Start()
    {
        _monk = GetComponentInParent<Monk>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _monk.CheckIfPlayerInCollider(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _monk.CheckIfPlayerInCollider(false);
    }
}
