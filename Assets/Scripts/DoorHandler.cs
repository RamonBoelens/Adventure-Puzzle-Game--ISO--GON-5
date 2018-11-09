using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DoorHandler requires the GameObject to have a Animator component
[RequireComponent(typeof(Animator))]
public class DoorHandler : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeDoorState()
    {
        if (animator.GetBool("isOpen"))
            CloseDoor();
        else
            OpenDoor();
    }

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpen", false);
    }
}
