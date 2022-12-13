using Ink.Runtime;
using TMPro;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public static Action<bool> OnInputEnabled;

    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _speech;

    private Story _currentStory;

    private void OnEnable()
    {
        DialogueCollider.OnDialogueEntered += StartDialogue;
    }

    private void OnDisable()
    {
        DialogueCollider.OnDialogueEntered -= StartDialogue;
    }

    private void StartDialogue(TextAsset jsonFile)
    {
        OnInputEnabled?.Invoke(false);
        _currentStory = new Story(jsonFile.text);
        _speech.text = _currentStory.Continue();
        _dialoguePanel.SetActive(true);
    }

    public void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _speech.text = _currentStory.Continue();
        } 
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        OnInputEnabled?.Invoke(true);
        _dialoguePanel.SetActive(false);
    }
}
