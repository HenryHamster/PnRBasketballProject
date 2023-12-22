using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Other1_Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Others;
    // public GameObject Def1, Def2, Def3, Def4, Def5;
    public Canvas canvas;
    public Image image1;
    public Image image2;
    public Image image3;
    // public float threshold;

    // Update is called once per frame
    void Update()
    {
        float zPosition = Others.transform.position.z;

        if (zPosition > 10.57f)
        {
            // O3 的 z 軸座標大於 threshold，置換為圖片 image1
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);

        }
        else if (zPosition <= 10.57f && zPosition >= 8.38f)
        {
            // O3 的 z 軸座標小於等於 threshold，置換為圖片 image2
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false);

        }
        else if (zPosition < 8.38f)
        {
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(true);
        }
    }
}
