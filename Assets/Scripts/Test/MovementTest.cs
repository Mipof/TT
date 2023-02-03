using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0);
    }
}
