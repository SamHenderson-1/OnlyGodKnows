using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private FirstPersonController player;
    [Tooltip("UI settings for the inventory")]
    public GameObject menuI;
    [Tooltip("UI settings for the journal")]
    public NoteSystem.NotesSystem menuJ;
    [Tooltip("UI settings for the pause menu")]
    public GameObject menuP;
    public static bool isPaused;
    private bool iActive = false;
    private bool pActive = false;
    private bool usingNotesSystem = false;

    // Start is called before the first frame update
    void Start()
    {
        menuI.SetActive(iActive);
        menuP.SetActive(pActive);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame && !isPaused)
        {
            Debug.Log("i");
            iActive = !iActive;
            menuI.SetActive(iActive);
            ActivateCursor();
        }

        if (Keyboard.current.tabKey.wasPressedThisFrame && !isPaused)
        {
            Debug.Log("Tab");
            usingNotesSystem = !usingNotesSystem;
            ActivateCursor();
            switch (usingNotesSystem)
            {
                case true:
                    menuJ.Open();
                    break;
                case false:
                    menuJ.Close((menuJ.activeNote != null) ? true : false);
                    break;
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            if (isPaused)
            {
                ResumeGame();
                ActivateCursor();
            }
            else
            {
                PauseGame();
                ActivateCursor();
            }
        }
    }

    private void ActivateCursor() 
    {
        if (isPaused || (iActive || usingNotesSystem))
        {
            player.disabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!pActive && !iActive && !usingNotesSystem) 
        {
            player.disabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void PauseGame() 
    { 
        pActive = true;
        menuP.SetActive(pActive);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pActive = false;
        menuP.SetActive(pActive);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
