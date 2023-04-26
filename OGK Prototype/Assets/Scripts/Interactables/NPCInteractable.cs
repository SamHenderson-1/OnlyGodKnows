using NoteSystem;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractable : Interactable
{

    [SerializeField]
    private TextMeshProUGUI npcText;
    [SerializeField]
    private Script[] dialogue;

    protected override void Interact()
    {
        npcText.color = dialogue[interactionCounter].color;
        npcText.text = dialogue[interactionCounter].line;
        StartCoroutine("Erase");
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(dialogue[interactionCounter].line.Split(' ').Length*0.3f + 1f);
        npcText.text = "";
    }
}
