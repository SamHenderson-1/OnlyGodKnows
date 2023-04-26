
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Main_Menu : MonoBehaviour
{
    [SerializeField]
    VideoPlayer player;
    [SerializeField]
    RawImage cutscene;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        Debug.Log("Loading Playground scene");
        cutscene.gameObject.SetActive(true);
        player.Play();
        player.loopPointReached += EndReached;
            
    }

    void EndReached(VideoPlayer vp)
    {
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
