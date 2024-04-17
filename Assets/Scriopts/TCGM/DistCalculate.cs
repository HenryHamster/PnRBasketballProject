using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistCalculate : MonoBehaviour
{

    public GameObject T4;
    public GameObject O6;
    public GameObject Line, Connection;

    public TextMeshProUGUI distanceText;
    public GameObject minimapDistanceText;
    public TextMeshProUGUI PnR_QuailtyText;
    public Image panelImage;
    public LineRenderer lineRenderer;

    // private Vector3 PnR_Handler_StartPosition = new Vector3(-1.765f, 0f, 3.960f);
    // private Vector3 PnR_Handler_EndPosition = new Vector3(-2.640f, 0f, 5.4f);
    // private Vector3 Def1_StartPosition = new Vector3(-1.300f, 0f, 6.963f);
    // private Vector3 Def1_EndPosition = new Vector3(-1.486f, 0f, 7.1f);

    private Vector3 t4StartPosition = new Vector3(-1.765f, 0f, 3.960f);
    private Vector3 t4EndPosition = new Vector3(-2.640f, 0f, 5.231f);
    private Vector3 o6StartPosition = new Vector3(-1.300f, 0f, 6.963f);
    private Vector3 o6EndPosition = new Vector3(-1.486f, 0f, 7.055f);

    private bool t4EnteredArea = false;
    private bool o6EnteredArea = false;

    private float dist;

    private void Start()
    {
        lineRenderer.enabled = false;
        // panelImage.SetActive(false);
        Line.SetActive(false);
        Connection.SetActive(false);
        panelImage.enabled = true;
        panelImage.color = new Color(1f, 1f, 1f, 0f);
    }

    private void Update()
    {
        bool t4InArea = T4.transform.position.z >= t4StartPosition.z && T4.transform.position.z <= t4EndPosition.z;
        // 檢查 O6 是否進入特定範圍
        bool o6InArea = O6.transform.position.z >= o6StartPosition.z && O6.transform.position.z <= o6EndPosition.z;

        if (t4InArea && o6InArea)
        {
            t4EnteredArea = true;
            o6EnteredArea = true;
            CalculateDistance();
            lineRenderer.enabled = true;
            DrawLineBetweenObjects(T4.transform.position, O6.transform.position);
            // panelImage.color = new Color(0f, 0.5f, 0f, 0.3f);
            // panelImage.SetActive(true);
            panelImage.color = new Color(0.6f, 0.93f, 0.56f, 0.3f);
            PnR_QuailtyText.text = "Good Distance";
            PnR_QuailtyText.color = Color.black;
            Line.SetActive(true);
            minimapDistanceText.SetActive(true);
            Connection.SetActive(true);


        }
        else
        {
            t4EnteredArea = false;
            o6EnteredArea = false;
            distanceText.text = "";
            PnR_QuailtyText.text = "";
            panelImage.color = new Color(1f, 1f, 1f, 0f);
            //panelImage.SetActive(false);
            Line.SetActive(false);
            minimapDistanceText.SetActive(false);

            lineRenderer.enabled = false;
            Connection.SetActive(false);

        }
    }

    private void CalculateDistance()
    {
        // Vector3 t4Center = T4.transform.position + T4.GetComponent<Renderer>().bounds.center;
        // Vector3 o6Center = O6.transform.position + O6.GetComponent<Renderer>().bounds.center;

        // float xDiff = (pos1.x - pos2.x) * (92f / 28f);
        // float yDiff = (pos1.y - pos2.y) * (50f / 15f);
        // return Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2)) * 0.3f;
        float xDiff = (T4.transform.position.x - O6.transform.position.x) * (50f / 15f);
        float zDiff = (T4.transform.position.z - O6.transform.position.z) * (92f / 28f);
        float distance = Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(zDiff, 2));
        // Debug.Log("Distance between T4 and O6: " + distance.ToString("F2"));
        //distanceText.SetText(distance.ToString("F2") + "ft");
        //distanceText.color = Color.black;
        // DrawLineBetweenObjects(t4Center, o6Center);

    }
    private void DrawLineBetweenObjects(Vector3 pos1, Vector3 pos2)
    {
        // lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
    }
}


// Vector3 pos1, Vector3 pos2
// Start is called before the first frame update
// public GameObject T4;
// public GameObject O6;
// public LineRenderer lineRenderer;
// public TextMeshProUGUI distanceText;

// private void Update()
// {
//     // 檢查 T4 和 O6 是否在特定位置範圍內
//     double t4X = T4.transform.position.x;
//     double t4Z = T4.transform.position.z;
//     double o6X = O6.transform.position.x;
//     double o6Z = O6.transform.position.z;

//     if (((t4X >= -4.13d && t4X <= -3.46d) && (t4Z <= 1.38d && t4Z >= 0.37d)) && ((o6X >= -2.97d && o6X <= -2.92d) && (o6Z <= 3.23d && o6Z >= 3.15d)))
//     {
//         Debug.Log(t4X);
//         // 計算距離
//         double distance = CalculateDistance(T4.transform.position, O6.transform.position);

//         // 繪製連線
//         //DrawLineBetweenObjects(T4.transform.position, O6.transform.position);

//         // 更新距離文字顯示
//         distanceText.text = "距離：" + distance.ToString("F2") + "ft";
//     }
//     else
//     {
//         // 隱藏連線和距離文字
//         //lineRenderer.enabled = false;
//         distanceText.text = "";
//     }
// }

// private double CalculateDistance(Vector3 pos1, Vector3 pos2)
// {
//     double xDiff = (pos1.x - pos2.x) * (92d / 28d);
//     double yDiff = (pos1.y - pos2.y) * (50d / 15d);
//     return Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2)) * 0.30d;

// }

// // private void DrawLineBetweenObjects(Vector3 pos1, Vector3 pos2)
// // {
// //     lineRenderer.enabled = true;
// //     lineRenderer.SetPosition(0, pos1);
// //     lineRenderer.SetPosition(1, pos2);
// // }