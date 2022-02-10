using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject arrowparent;
    private Vector3 offset = new Vector3(1.21f, 3.06f, -10.74f), arrowtransform;
    public float smoothness;

    private void Start()
    {
        arrowtransform = arrowparent.transform.position;
        transform.position = arrowtransform + offset;
    }

    private void Update()
    {
        arrowtransform = arrowparent.transform.position;
        transform.position = Vector3.Lerp(transform.position, arrowtransform + offset, smoothness);
    }
}
