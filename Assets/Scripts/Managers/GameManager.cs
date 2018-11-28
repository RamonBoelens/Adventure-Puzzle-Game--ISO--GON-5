using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // Access point for other scripts
    public static GameManager instance;

    public Text scorefield;
    public Text healthField;

    int score;

    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Keep this game object alive while going through different scenes
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        ResetScore();
        UpdateScoreField();
    }

    public void GameOver()
    {
        MenuManager.instance.SwitchScene(9);
        ResetScore();
    }

    public void AddScore(int _score)
    {
        score += _score;
        UpdateScoreField();
    }

    void ResetScore()
    {
        score = 0;
        UpdateScoreField();
    }

    void UpdateScoreField()
    {
        scorefield.text = "Score: " + score.ToString();
    }

    public void UpdateHealthField(int _health)
    {
        healthField.text = "Health: " + _health.ToString();
    }
}
