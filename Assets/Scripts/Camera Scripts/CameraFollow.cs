using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;

    // Update called after everything else updated
    private void LateUpdate()
    {
        if (target == null)
            Debug.LogError("Camera couldn't find " + target + " as a target!");
        else
            FollowTarget();
    }

    // Follow a target with a certain distance
    private void FollowTarget()
    {
        transform.position = target.transform.position + new Vector3(-10, 10, -10);
    }
}
