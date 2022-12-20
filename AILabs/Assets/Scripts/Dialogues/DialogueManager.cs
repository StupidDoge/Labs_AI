using Ink.Runtime;
using TMPro;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public static Action<bool> OnInputEnabled;
    public static Action OnDialogueEnded;

    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _speech;

    private Story _currentStory;

    private void OnEnable()
    {
        Monk.OnDialogueStarted += StartDialogue;
    }

    private void OnDisable()
    {
        Monk.OnDialogueStarted -= StartDialogue;
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
        OnDialogueEnded?.Invoke();
    }
}
