using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassRateDisplay : MonoBehaviour
{
    // public Dropdown dropdown;
    private Pass3 pass;
    private Pass3 pass1;
    private Pass3 pass2;
    private Pass4 pass3;
    private Pass5 pass4;


    public TextMeshProUGUI buttonText;
    public GameObject P1, P2, P3, P4, P5;

    private bool isDisplay = false;
    // Start is called before the first frame update
    void Start()
    {
        pass = P1.GetComponent<Pass3>();
        pass1 = P2.GetComponent<Pass3>();
        pass2 = P3.GetComponent<Pass3>();
        pass3 = P4.GetComponent<Pass4>();
        pass4 = P5.GetComponent<Pass5>();

        pass.gameObject.SetActive(false);
        pass1.gameObject.SetActive(false);
        pass2.gameObject.SetActive(false);
        pass3.gameObject.SetActive(false);
        pass4.gameObject.SetActive(false);
        // buttonText.text = "Success Rate(Show)";
    }


    public void OnButtonClick()
    {
        // 點擊按鈕時，設定 buttonClicked 為 true
        // buttonClicked = true;
        isDisplay = !isDisplay;
        if (isDisplay)
        {
            buttonText.text = "Hide";
            pass.gameObject.SetActive(true);
            pass1.gameObject.SetActive(true);
            pass2.gameObject.SetActive(true);
            pass3.gameObject.SetActive(true);
            pass4.gameObject.SetActive(true);

        }
        else
        {
            buttonText.text = "Show";
            pass.gameObject.SetActive(false);
            pass1.gameObject.SetActive(false);
            pass2.gameObject.SetActive(false);
            pass3.gameObject.SetActive(false);
            pass4.gameObject.SetActive(false);


        }

    }
    // Update is called once per frame

}
