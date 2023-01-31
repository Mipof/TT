using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _offset;


    public float GetOffset()
    {
        return _offset;
    }
}
