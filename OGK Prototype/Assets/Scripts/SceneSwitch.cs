using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NoteSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class SceneSwitch : Interactable
{
    public int sceneToSwitchTo;
    [SerializeField] bool requiresNote;
    private string holdMessage;
    [SerializeField] bool hasTransition;
    [SerializeField]
    VideoPlayer video;
    [SerializeField]
    RawImage cutscene;
    GameObject[] enemies;
    [SerializeField]
    SoundTrigger soundTrigger;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected override void Interact()
    {
        player.startingText = player.startingNote.Pages[0].text;
        if (requiresNote)
        {
            if (player.menuJ.noteDatas.Count >= 3)
                SceneManager.LoadScene(sceneToSwitchTo);
            else
                holdMessage = promptMessage;
                promptMessage = "There must be something I'm missing, I can't go yet.";
                StartCoroutine("Erase");
        }
        else
        {
            Debug.Log("Loading Ending scene");
            if (hasTransition) 
                Transition();
            else
                SceneManager.LoadScene(sceneToSwitchTo);
        }
    }
    private void Transition() {
        soundTrigger.playSound.Stop();
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        promptMessage = "";
        UIManager.isPaused = true;
        cutscene.gameObject.SetActive(true);
        video.Play();
        video.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToSwitchTo);
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(5f);
        promptMessage = "";
        promptMessage = holdMessage;
    }
}
