using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBall_A_Tendency : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Off1, Image1, Image2, Image3;

    void Start()
    {
        Image1.SetActive(true);
        Image2.SetActive(false);
        Image3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Off1.transform.position.z;
        if (pos <= 3.8f)
        {
            Image1.SetActive(true);
            Image2.SetActive(false);
            Image3.SetActive(false);
        }
        else if (pos > 3.8f && pos <= 6.2f)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            Image3.SetActive(false);
        }
        else if (pos > 6.2f)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(true);

        }
    }
}
