using UnityEngine;
using System.Collections;


namespace NotesSystem
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
                NotesSystem.Display(note);
            }
            if (add)
            {
                NotesSystem.AddNote(note.Label, note);
                Destroy(gameObject);
            }
        }
    }
}