using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    [Range(1, 5)]
    float speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    // Check for player input and move accordingly
    private void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);
        }
    }
}
