﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAndPull : MonoBehaviour {

    GameObject objectInTrigger;
    GameObject dragableTarget;

    Vector3 currentHeading;

    PlayerControllerIsometric playerController;

    Vector3 facingUp = new Vector3(0.70710680f, 0.0f, 0.70710680f);
    Vector3 facingDown = new Vector3(-0.70710680f, 0.0f, -0.70710680f);
    Vector3 facingRight = new Vector3(0.70710680f, 0.0f, -0.70710680f);
    Vector3 facingLeft = new Vector3(-0.70710680f, 0.0f, 0.70710680f);

    private void Awake()
    {
        // Reference to the playerController
        playerController = GetComponent<PlayerControllerIsometric>();
    }

    // Update is called once per frame
    void Update () {
        if (dragableTarget == null)
            return;
        else
            DragObject();
	}

    // When entering the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object in the trigger has a obstacle component attached to it
        if (other.GetComponent<Obstacle>())
        {
            // Check if this object is moveable
            if (other.GetComponent<Obstacle>().GetMoveableObject() == true)
            {
                // Set the object to use in the other triggers
                objectInTrigger = other.gameObject;

                /*
                // Set the dragable target automatically when close to the object
                dragableTarget = other.gameObject;
                Debug.Log("The dragable target is now set to " + dragableTarget);
                */
            }
        }  
    }

    // When in the trigger
    private void OnTriggerStay(Collider other)
    {
        // Check if the object in the trigger has a obstacle component attached to it
        if (other.GetComponent<Obstacle>())
        {
            // Check if this object is moveable
            if (other.GetComponent<Obstacle>().GetMoveableObject() == true)
            {
                // Press E to set the dragable object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // If you don't have a object selected then select it
                    if (!dragableTarget)
                    {
                        dragableTarget = objectInTrigger;
                        Debug.Log("The dragable target is now set to " + dragableTarget);

                        ChangePlayerSpeed();
                        CheckHeading();
                        DragObject();
                    }
                    // Otherwise unselect the current object
                    else
                    {
                        dragableTarget = null;
                        Debug.Log("You've unselected the target.");

                        ChangePlayerSpeed();
                        playerController.SetDisableMovement(false, false);
                    }
                }
            }
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        objectInTrigger = null;
        dragableTarget = null;

        Debug.Log("Out of range of " + other);
    }
    */

    private void ChangePlayerSpeed()
    {
        float newSpeed;

        // If no dragable object is selected increase the player's speed
        if (!dragableTarget)
        {
            newSpeed = playerController.GetMoveSpeed() * 2.0f;
            playerController.SetMoveSpeed(newSpeed);
        }
        // If a dragable object is selected decrease the player's speed
        else
        {
            newSpeed = playerController.GetMoveSpeed() * 0.5f;
            playerController.SetMoveSpeed(newSpeed);
        }
    }

    private void CheckHeading()
    {
        // Get the current heading of the player
        currentHeading = playerController.GetHeading();

        // If using horizontal axis disable the vertical movement
        if (currentHeading == facingUp || currentHeading == facingDown)
            playerController.SetDisableMovement(false, true);
        // If using vertical axis disable the horizontal movement
        else if (currentHeading == facingRight || currentHeading == facingLeft)
            playerController.SetDisableMovement(true, false);
    }

    // Check the current rotation of the player and place the dragable object in front of the player
    private void DragObject()
    {
        Vector3 margin;

        if (currentHeading == facingUp)
        {
            margin = new Vector3(1.5f, 0, 1.5f);
            dragableTarget.transform.position = new Vector3(transform.position.x, dragableTarget.transform.position.y, transform.position.z) + margin;
        }
        else if (currentHeading == facingDown)
        {
            margin = new Vector3(1.5f, 0, 1.5f);
            dragableTarget.transform.position = new Vector3(transform.position.x, dragableTarget.transform.position.y, transform.position.z) - margin;
        }
        else if (currentHeading == facingRight)
        {
            margin = new Vector3(1.5f, 0, -1.5f);
            dragableTarget.transform.position = new Vector3(transform.position.x, dragableTarget.transform.position.y, transform.position.z) + margin;
        }
        else if (currentHeading == facingLeft)
        {
            margin = new Vector3(1.5f, 0, -1.5f);
            dragableTarget.transform.position = new Vector3(transform.position.x, dragableTarget.transform.position.y, transform.position.z) - margin;
        }

        

    }
}
