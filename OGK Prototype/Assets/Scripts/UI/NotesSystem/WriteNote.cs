using NoteSystem;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WriteNote : MonoBehaviour
{
    public string noteText;
    public int currentPage;
    public bool entered = false;
    public FirstPersonController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !entered) 
        {
            //if(player.startingNote.Pages[currentPage].text.Length >= )
            player.startingNote.Pages[currentPage].text = player.startingNote.Pages[currentPage].text + "\n\n" + noteText;
            entered = true;
        }
            
    }
}
