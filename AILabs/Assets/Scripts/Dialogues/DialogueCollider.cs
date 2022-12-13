using System;
using UnityEngine;

public class DialogueCollider : MonoBehaviour
{
    public static Action<TextAsset> OnDialogueEntered;

    [SerializeField] private TextAsset _textAsset;

    private bool _isVisited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isVisited)
        {
            OnDialogueEntered?.Invoke(_textAsset);
            _isVisited = true;
        }
    }
}
