using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogueStateData", menuName = "NPC Data/State Data/Dialogue State")]
public class NPCDialogueStateData : ScriptableObject
{
    public TextAsset StartDialogue;
    public TextAsset EndDialogue;
}
