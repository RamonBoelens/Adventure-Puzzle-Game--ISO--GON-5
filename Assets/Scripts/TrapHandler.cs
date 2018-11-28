using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHandler : MonoBehaviour {

    public int spikeDamage = 50;

    private void OnTriggerEnter(Collider other)
    {
        // If something else then the player is in the trigger zone then ignore it
        if (other.tag != "Player")
            return;
        else if (tag == "Spikes")
        {
            other.GetComponent<PlayerStats>().AddHealth(-spikeDamage);
        }
    }
}
