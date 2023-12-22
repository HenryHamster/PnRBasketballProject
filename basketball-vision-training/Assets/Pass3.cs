using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Pass3 : MonoBehaviour
{
    public GameObject Player;
    // public GameObject Cube1, Cube2;
    public GameObject Ratio;
    public GameObject line;
    //public TextMeshProUGUI Text;
    public Image panel;
    // Start is called before the first frame update
    void Start()
    {
        // Cube1.gameObject.SetActive(false);
        // Cube2.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        Ratio.SetActive(false);
        panel.enabled = false;
        //Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Player.transform.position.z;

        if (pos >= 11.27f && pos <= 11.72f)
        {
            // Cube1.gameObject.SetActive(true);
            // Cube2.gameObject.SetActive(true);
            line.gameObject.SetActive(true);
            Ratio.SetActive(true);

            panel.enabled = true;
            //Text.enabled = true;

        }
    }
}
