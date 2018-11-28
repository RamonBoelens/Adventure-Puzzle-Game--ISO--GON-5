using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int damage = 100;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
            return;
        else
        {
            other.GetComponent<PlayerStats>().AddHealth(-damage);
        }
    }
}
