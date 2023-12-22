using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOffBallChart : MonoBehaviour
{
    public Toggle DisplayChart;
    public GameObject chart1, chart2, chart3;
    // Start is called before the first frame update
    void Start()
    {
        DisplayChart.isOn = true;
    }

    // Update is called once per frame
    public void OnToggleClick()
    {
        if (DisplayChart.isOn)
        {
            chart1.SetActive(true);
            chart2.SetActive(true);
            chart3.SetActive(true);

        }
        else
        {
            chart1.SetActive(false);
            chart2.SetActive(false);
            chart3.SetActive(false);
        }
        // PnR_Dist_Toggle.interactable = false;
    }
}
