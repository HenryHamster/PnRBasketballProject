using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Generate : MonoBehaviour
{
    public GameObject BallHandler;
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BallHandler.transform.position.z > 2.25f)
        {
            // Debug.Log("true" + BallHandler.transform.position.z);
            // Ball.GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0f);
            Ball.SetActive(true);
        }
        else
        {
            // Debug.Log("false" + BallHandler.transform.position.z);

            Ball.SetActive(false);
        }
    }
}
