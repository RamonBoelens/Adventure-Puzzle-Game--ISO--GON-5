using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that handles all the pickups
public class PickUpHandler : MonoBehaviour {

    int CoinPoints = 10;
    int GemPoints = 20;
    int TreasureChestPoints = 50;
    int StatuePoints = 35;

    private void OnTriggerStay(Collider other)
    {
        // If something else then the player is in the trigger zone then ignore it
        if (other.tag != "Player")
            return;
        // If the player hits a key open the door
        else if (tag == "Key")
        {
            GetComponent<Key>().LinkedDoor.GetComponent<DoorHandler>().OpenDoor();
            Destroy(gameObject);
        }
        // If the player pulls a lever then open or close the door depending on its current state
        else if (tag == "Lever")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetComponent<Key>().LinkedDoor.GetComponent<DoorHandler>().ChangeDoorState();

                // Lever Animation
                Animator animator = GetComponent<Animator>();
                if (animator.GetBool("isUp"))
                    animator.SetBool("isUp", false);
                else
                    animator.SetBool("isUp", true);
            }
        }
        // If the player hits treasure add different score depending on the treasure
        else if (tag == "Coin")
        {
            GameManager.instance.AddScore(CoinPoints);
            Destroy(gameObject);
        }
        else if (tag == "Gem")
        {
            GameManager.instance.AddScore(GemPoints);
            Destroy(gameObject);
        }
        else if (tag == "Treasure Chest")
        {
            GameManager.instance.AddScore(TreasureChestPoints);
            Destroy(gameObject);
        }
        else if (tag == "Statue")
        {
            GameManager.instance.AddScore(StatuePoints);
            Destroy(gameObject);
        }
    }
}
