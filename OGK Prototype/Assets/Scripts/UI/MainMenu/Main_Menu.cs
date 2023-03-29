
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Loading Playground scene");
        SceneManager.LoadScene("Midwich");
    }

    public void Options()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
