using UnityEngine;
using System.Collections;


namespace NoteSystem
{
    public class NotePickup : Interactable
    {
        [SerializeField] Note note = null;

        [SerializeField] bool autoDisplay = false;
        [SerializeField] bool add = true;

        protected override void Interact()
        {
            if (autoDisplay)
            {
                FindObjectOfType<NotesSystem>().DisplayNote(note);
            }
            if (add)
            {
                NotesSystem.AddNote(note.Label, note);
                Destroy(gameObject);
            }
        }
    }
}