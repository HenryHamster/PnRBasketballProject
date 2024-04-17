using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Pass4 : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ratio;
    public GameObject line;
    public TextMeshProUGUI Text;
    public Image panel;
    // Start is called before the first frame update
    void Start()
    {
        // Cube1.gameObject.SetActive(false);
        // Cube2.gameObject.SetActive(false);
        line.gameObject.SetActive(false);
        Ratio.SetActive(false);
        panel.enabled = false;
        Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float pos = Player.transform.position.z;

        if (pos >= 5.6f && pos <= 6.1f)
        {
            // Cube1.gameObject.SetActive(true);
            // Cube2.gameObject.SetActive(true);
            line.gameObject.SetActive(true);
            Ratio.SetActive(true);

            panel.enabled = true;
            Text.enabled = true;

        }
        else
        {
            line.gameObject.SetActive(false);
            Ratio.SetActive(false);
            panel.enabled = false;
            Text.enabled = false;
        }
    }
}
