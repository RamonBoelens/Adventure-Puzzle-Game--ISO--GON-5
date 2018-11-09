using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    // Access point for other scripts
    public static MenuManager instance;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        // Keep this game object alive while going through different scenes
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void CloseProgram()
    {
        Application.Quit();
    }
}
