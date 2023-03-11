using UnityEngine;
using System.Collections;


namespace NotesSystem
{
    public class NotePickUp : MonoBehaviour, IInteractable
    {
        [SerializeField] Note note = null;

        [SerializeField] bool autoDisplay = false;
        [SerializeField] bool add = true;

        public void Interact()
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