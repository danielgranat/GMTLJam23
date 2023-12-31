using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void OnLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
