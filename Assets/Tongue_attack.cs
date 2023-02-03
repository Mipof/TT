using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue_attack : MonoBehaviour
{

    LineRenderer line;
    Vector3 originalpos = new Vector3(540.6785f, -6.339138f, 1.0f);
    private void Awake()
    {
      
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tongue (Transform transform)
    {
        line.SetPosition(0, transform.position);
    }

    public void tongueoriginalpos ()
    {
        line.SetPosition(0, originalpos);
    }
}
