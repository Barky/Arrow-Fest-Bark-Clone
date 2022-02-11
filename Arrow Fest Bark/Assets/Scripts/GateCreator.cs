using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCreator : MonoBehaviour
{
    public GameObject gatePrefab;
    private Vector3 position_ = Vector3.zero;
    public float distance;

    private void Awake()
    {
        //transform.position = GameObject.Find("parent").transform.position;
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            position_ += new Vector3(0f, 0f, distance);
            GameObject new_ =  Instantiate(gatePrefab, this.transform);
            new_.transform.localPosition += position_;

        }
    }
}
