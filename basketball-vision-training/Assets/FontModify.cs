using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FontModify : MonoBehaviour
{
    public GameObject player;
    public Text PlayerNumber;
    public GameObject MainCamera;
    public float distanceThreshold = 10f;
    public int largeFontSize = 80;
    public int smallFontSize = 50;


    void Start()
    {
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, MainCamera.transform.position);
        // Debug.Log(distance);

        if (distance > distanceThreshold)
        {
            //PlayerNumber.fontSize = largeFontSize;
        }
        else
        {
            //PlayerNumber.fontSize = smallFontSize;
        }
    }
}