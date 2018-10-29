using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerIsometric : MonoBehaviour
{

    [SerializeField]
    [Range(1, 5)]
    float moveSpeed = 4f;

    Vector3 forward, right, heading;

    public bool disableHorizontalMovement = false;
    public bool disableVerticalMovement = false;

    bool disableRotation = false;

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            Move();
    }

    // Check for player input and move accordingly
    private void Move()
    {
        Vector3 rightMovement;
        Vector3 upMovement;

        if (disableHorizontalMovement)
        {
            upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey") * 0;
            rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        }
        else if (disableVerticalMovement)
        {
            upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
            rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey") * 0;
        }
        else
        {
            upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
            rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        }

        // Create direction
        heading = Vector3.Normalize(rightMovement + upMovement);

        // Rotation
        if (disableRotation == false)
            transform.forward = heading;

        // Movement
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float _newSpeed)
    {
        moveSpeed = _newSpeed;
    }

    public Vector3 GetHeading()
    {
        return heading;
    }

    public void SetDisableMovement(bool _disableHorizontalMovement, bool _disableVerticalMovement)
    {
        // Disable the rotation when a block is grabbed
        if (_disableHorizontalMovement || _disableVerticalMovement == true)
            disableRotation = true;
        else
            disableRotation = false;

        disableHorizontalMovement = _disableHorizontalMovement;
        disableVerticalMovement = _disableVerticalMovement;
    }
}
