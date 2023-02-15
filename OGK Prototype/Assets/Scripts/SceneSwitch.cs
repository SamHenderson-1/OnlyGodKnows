using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int sceneToSwitchTo;
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
