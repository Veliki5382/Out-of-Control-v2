using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Camera camera;
    public Transform target;
    private Vector3 velocity;
    public float smooth;
    public Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + cameraOffset, ref velocity, smooth);
        //GetComponent<Camera>().orthographicSize = 3;
    }
}
