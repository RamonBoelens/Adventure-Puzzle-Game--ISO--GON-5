using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    public GameObject target;
    Vector3 isometricView = new Vector3(30, 45, 0);

	// Use this for initialization
	void Start () {
        SetRotation();
	}

    // Update called after everything else updated
    private void LateUpdate()
    {
        if (target == null)
            Debug.LogError("Camera couldn't find " + target + " as a target!");
        else
            FollowTarget();
    }

    // Set the rotation of the camera so it's in isometric view
    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(isometricView);
    }

    // Follow a target with a certain distance
    private void FollowTarget()
    {
        transform.position = target.transform.position - new Vector3(10, -10, 10);
    }
}
