using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUser : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject user;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Camera.main.transform.position;
        target.y = transform.position.y;
        transform.LookAt(target/* Vector3.forward * Camera.main.transform.position.z + Vector3.right * Camera.main.transform.position.x*/, Vector3.up) ;
        
        gameObject.transform.eulerAngles = gameObject.transform.eulerAngles + new Vector3(0.0f, 180f, 0.0f);

    }
}
