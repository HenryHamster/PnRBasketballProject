using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Destroy : MonoBehaviour
{
    public GameObject Ball;
    public GameObject T1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        return;
        // float pos = T1.transform.position.x;
        // Debug.Log(pos);
        // Debug.Log(T1.transform.position.x);
        if (T1.transform.position.x >= 1.96f)
        {
            // Ball.GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0f);
            Ball.SetActive(true);
            // Ball.SetActive(false);
        }
        else
        {
            Ball.SetActive(false);
        }
    }
}
