using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricView : MonoBehaviour {

    // Isometric view
    Vector3 isometricView = new Vector3(30, 45, 0);

    [SerializeField]
    [Range(10, 30)]
    float cameraSize = 15;

    // Use this for initialization
    void Start () {
        SetRotation();

        // Set the camera to orthographic and set its size
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = cameraSize;
	}

    // Set the rotation of the camera so it's in isometric view
    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(isometricView);
    }
}
