using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    int health = 100;

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int _health)
    {
        health += _health;
    }
}
