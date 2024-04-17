using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T4_Pos : MonoBehaviour
{
    public GameObject T4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(T4.transform.position);
        // Debug.Log(T4.transform.position.y);
        // Debug.Log(T4.transform.position.z);


    }
}
