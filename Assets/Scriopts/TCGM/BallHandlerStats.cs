using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallHandlerStats : MonoBehaviour
{
    public GameObject BallHandler;
    //public GameObject ShootUp, ShootDown, PassUp, PassDown;
    //public TextMeshProUGUI Shooting;
    //public TextMeshProUGUI Passing;
    public GameObject Image1, Image2, Image3, Image4, Image5, Image6;
    // public Text Passing;
    // Start is called before the first frame update
    void Start()
    {
        // ShootUp.gameObject.SetActive(false);
        // ShootDown.gameObject.SetActive(false);
        // PassUp.gameObject.SetActive(false);
        // PassDown.gameObject.SetActive(false);
        Image1.SetActive(true);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);
        Image6.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        float T4Z = BallHandler.transform.position.z;
        if (T4Z >= 1.0f && T4Z <= 3.72f)
        {
            Image1.SetActive(true);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(false);
            Image5.SetActive(false);
            Image6.SetActive(false);

            // Shooting.text = "Shoot Prob. 42%";
            // Passing.text = "Pass  Prob. 25%";
            // ShootUp.gameObject.SetActive(false);

            // ShootDown.gameObject.SetActive(false);
            // PassUp.gameObject.SetActive(false);
            // PassDown.gameObject.SetActive(false);
        }
        else if (T4Z < 6.94f && T4Z > 3.72f)
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            Image3.SetActive(false);
            Image4.SetActive(false);
            Image5.SetActive(false);
            Image6.SetActive(false);
            // Shooting.text = "Shoot Prob. 30%";
            // Passing.text = "Pass  Prob. 45%";
            // ShootUp.gameObject.SetActive(false);

            // ShootDown.gameObject.SetActive(true);
            // PassUp.gameObject.SetActive(true);
            // PassDown.gameObject.SetActive(false);
        }
        else if (T4Z >= 6.94f && T4Z < 8.6f)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(true);
            Image4.SetActive(false);
            Image5.SetActive(false);
            Image6.SetActive(false);
            // Shooting.text = "Shoot Prob. 52%";
            // Passing.text = "Pass  Prob. 34%";
            // ShootUp.gameObject.SetActive(true);

            // ShootDown.gameObject.SetActive(false);
            // PassUp.gameObject.SetActive(false);
            // PassDown.gameObject.SetActive(true);
        }
        else if (T4Z < 9.5f && T4Z >= 8.6f)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(true);
            Image5.SetActive(false);
            Image6.SetActive(false);
            // Shooting.text = "Shoot Prob. 62%";
            // Passing.text = "Pass  Prob. 34%";
            // ShootUp.gameObject.SetActive(true);

            // ShootDown.gameObject.SetActive(false);
            // PassUp.gameObject.SetActive(false);
            // PassDown.gameObject.SetActive(false);
        }
        else if (T4Z < 10.0f && T4Z >= 9.5f)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(false);
            Image5.SetActive(true);
            Image6.SetActive(false);
            // Shooting.text = "Shoot Prob. 65%";
            // Passing.text = "Pass  Prob. 33%";
            // ShootUp.gameObject.SetActive(true);

            // ShootDown.gameObject.SetActive(false);
            // PassUp.gameObject.SetActive(false);
            // PassDown.gameObject.SetActive(true);
        }
        else if (T4Z >= 10.0f)
        {
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(false);
            Image5.SetActive(false);
            Image6.SetActive(true);
            // Shooting.text = "Shoot Prob. 65%";
            // Passing.text = "Pass  Prob. 33%";
            // ShootUp.gameObject.SetActive(true);

            // ShootDown.gameObject.SetActive(false);
            // PassUp.gameObject.SetActive(false);
            // PassDown.gameObject.SetActive(true);
        }
    }
}

// using UnityEngine;
// using UnityEngine.UI;

// public class BallHandlerChart : MonoBehaviour
// {
//     public GameObject T4;

//     public Text Shooting;
//     public Text Passing;

//     private void Update()
//     {
//         // 檢查 O3 物件的 X 軸位置是否在指定範圍內
//         float T4X = T4.transform.position.x;
//         if (T4X >= -3.4f && T4X <= -1.6f)
//         {
//             Shooting = "投籃傾向：37%";
//             Passing = "傳球傾向：50%";
//         }
//         else
//         {
//             Shooting = "";
//             Passing = "";
//         }
//     }