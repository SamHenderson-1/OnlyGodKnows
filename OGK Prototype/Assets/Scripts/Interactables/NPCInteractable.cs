using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteractable : Interactable
{

    [SerializeField]
    private TextMeshProUGUI npcText;
    [SerializeField]
    private string dialogue;


    protected override void Interact()
    {
        npcText.text = dialogue;
        StartCoroutine("Erase");
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(5f);
        npcText.text = "";
    }
}
