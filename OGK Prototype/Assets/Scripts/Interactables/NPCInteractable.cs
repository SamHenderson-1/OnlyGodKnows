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
    private string[] dialogue;

    protected override void Interact()
    {
        npcText.text = dialogue[interactionCounter];
        StartCoroutine("Erase");
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(dialogue[interactionCounter].Split(' ').Length*0.3f + 3f);
        npcText.text = "";
    }
}
