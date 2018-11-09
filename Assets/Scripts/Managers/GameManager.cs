using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Access point for other scripts
    public static GameManager instance;

    int score;

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

    // Use this for initialization
    void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int _score)
    {
        score += _score;
        Debug.Log("Added " + _score + " points. Total points are " + score + " now.");
    }
}
