using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLegend : MonoBehaviour
{
    // Start is called before the first frame update

    public Toggle LegendToggle;
    public GameObject Legend;
    private void Start()
    {
        LegendToggle.isOn = false;
        Legend.SetActive(false);
    }

    public void OnToggleClick()
    {
        if (LegendToggle.isOn)
        {
            Legend.SetActive(true);
        }
        else
        {
            Legend.SetActive(false);
        }
    }
}
