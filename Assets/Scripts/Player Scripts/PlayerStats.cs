using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    int health = 100;

    private void Start()
    {
        GameManager.instance.UpdateHealthField(health);
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddHealth(int _health)
    {
        health += _health;

        GameManager.instance.UpdateHealthField(health);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
