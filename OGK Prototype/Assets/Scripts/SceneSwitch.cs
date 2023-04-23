using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NoteSystem;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToSwitchTo;
    public FirstPersonController player;
    void OnTriggerEnter(Collider other)
    {
        player.startingText = player.startingNote.Pages[0].text;
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
