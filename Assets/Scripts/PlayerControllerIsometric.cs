using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerIsometric : MonoBehaviour
{

    [SerializeField]
    [Range(1, 5)]
    float moveSpeed = 4f;

    Vector3 forward, right;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input from the player
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            Move();
    }

    // Check for player input and move accordingly
    private void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        // Create direction
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        // Rotation
        transform.forward = heading;

        // Movement
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}
