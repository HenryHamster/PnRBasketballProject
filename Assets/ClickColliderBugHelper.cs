using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickColliderBugHelper : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //rb.isKinematic = !rb.isKinematic;
    }

}
