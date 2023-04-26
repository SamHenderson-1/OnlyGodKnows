using NoteSystem;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;
    public Note interactionNote;
    public int interactionCounter = 0;
    public int alarm;
    public bool newNote;
    public string noteText;
    public int currentPage = 0;
    [SerializeField]
    public FirstPersonController player;

    public void BaseInteract()
    {
        Interact();
        interactionCounter++;

    }

    public void TakeNote() 
    {
        if (interactionCounter == alarm)
        {
            //if(player.startingNote.Pages[currentPage].text.Length >= )
            if (!newNote)
                player.startingNote.Pages[currentPage].text = player.startingNote.Pages[currentPage].text + "\n\n" + noteText;
            else
                NotesSystem.AddNote(interactionNote.Label, interactionNote);
        }
    }

    protected virtual void Interact()
    {

    }
}