using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NoteSystem;
using TMPro;

public class SceneSwitch : Interactable
{
    public int sceneToSwitchTo;
    [SerializeField] bool requiresNote;
    private string holdMessage;

    protected override void Interact()
    {
        player.startingText = player.startingNote.Pages[0].text;
        if (requiresNote)
        {
            if (player.menuJ.noteDatas.Count == 3)
                SceneManager.LoadScene(sceneToSwitchTo);
            else
                holdMessage = promptMessage;
                promptMessage = "There must be something I'm missing, I can't go yet.";
                StartCoroutine("Erase");
        }
        else
        {
            SceneManager.LoadScene(sceneToSwitchTo);
        }
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(5f);
        promptMessage = "";
        promptMessage = holdMessage;
    }
}
