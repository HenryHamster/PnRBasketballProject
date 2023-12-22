using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BallHandlerPass : MonoBehaviour
{
    public GameObject BallHandller;
    public GameObject pass1_rec1, pass1_rec2, pass1_rec3, pass1_rec4;

    public GameObject pass2_rec1, pass2_rec2, pass2_rec3, pass2_rec4;
    public GameObject pass3_rec1, pass3_rec2, pass3_rec3, pass3_rec4;
    public GameObject line1, line2, line3;
    public Image pass1, pass2, pass3;
    public Image pass1_panel, pass2_panel, pass3_panel;
    public TextMeshProUGUI pass1_per, pass2_per, pass3_per, pass1_total, pass2_total, pass3_total;
    // Start is called before the first frame update
    // public GameObject Sphere;
    // public TextMeshProUGUI pass1text;
    void Start()
    {
        // pass1_text.text = "";
        // SphereRender = Sphere.GetComponent<Renderer>();
        // Sphere.SetActive(false);
        pass1.enabled = false;
        pass2.enabled = false;
        pass3.enabled = false;

        pass1_per.text = "";
        pass2_per.text = "";
        pass3_per.text = "";

        pass1_total.text = "";
        pass2_total.text = "";
        pass3_total.text = "";

        pass1_rec1.gameObject.SetActive(false);
        pass1_rec2.gameObject.SetActive(false);
        pass1_rec3.gameObject.SetActive(false);
        pass1_rec4.gameObject.SetActive(false);

        pass2_rec1.gameObject.SetActive(false);
        pass2_rec2.gameObject.SetActive(false);
        pass2_rec3.gameObject.SetActive(false);
        pass2_rec4.gameObject.SetActive(false);

        pass3_rec1.gameObject.SetActive(false);
        pass3_rec2.gameObject.SetActive(false);
        pass3_rec3.gameObject.SetActive(false);
        pass3_rec4.gameObject.SetActive(false);

        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        line3.gameObject.SetActive(false);

        pass1_panel.gameObject.SetActive(false);
        pass2_panel.gameObject.SetActive(false);
        pass3_panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float pos = BallHandller.transform.position.z;

        if (pos >= 11.27f && pos <= 11.72f)
        {
            // pass1.enabled = true;
            // pass1.color = new Color(0.8f, 0.2f, 0.2f);
            // pass1_text.text = "Pass SUCC 53%(16/30)";
            // pass1_text.color = new Color(0.8f, 0.2f, 0.2f);
            // pass2.enabled = true;
            // pass2.color = new Color(0.8f, 0.2f, 0.2f);
            // pass2_text.text = "Pass SUCC 42%(31/75)";
            // pass2_text.color = new Color(0.8f, 0.2f, 0.2f);

            pass1.enabled = true;
            pass1.color = new Color(1f, 0f, 0f, 0.3f);
            pass1_per.text = "36%";
            pass1_total.text = "(32/89)";
            pass1_per.color = new Color(1f, 0f, 0f);
            pass1_total.color = new Color(1f, 0f, 0f);

            pass1_rec1.gameObject.SetActive(true);
            pass1_rec2.gameObject.SetActive(true);
            pass1_rec3.gameObject.SetActive(true);
            pass1_rec4.gameObject.SetActive(true);

            pass1_rec1.GetComponent<Renderer>().material.color = Color.red;
            pass1_rec2.GetComponent<Renderer>().material.color = Color.red;
            pass1_rec3.GetComponent<Renderer>().material.color = Color.black;
            pass1_rec4.GetComponent<Renderer>().material.color = Color.black;

            pass2.enabled = true;
            pass2.color = new Color(1f, 0f, 0f, 0.3f);
            pass2_per.text = "55%";
            pass2_total.text = "(70/127)";
            pass2_per.color = new Color(1f, 0f, 0f);
            pass2_total.color = new Color(1f, 0f, 0f);

            pass2_rec1.gameObject.SetActive(true);
            pass2_rec2.gameObject.SetActive(true);
            pass2_rec3.gameObject.SetActive(true);
            pass2_rec4.gameObject.SetActive(true);

            pass2_rec1.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec2.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec3.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec4.GetComponent<Renderer>().material.color = Color.black;

            pass3.enabled = true;
            pass3.color = new Color(1f, 0f, 0f, 0.3f);
            pass3_per.text = "20%";
            pass3_total.text = "(5/25)";
            pass3_per.color = new Color(1f, 0f, 0f);
            pass3_total.color = new Color(1f, 0f, 0f);


            pass3_rec1.gameObject.SetActive(true);
            pass3_rec2.gameObject.SetActive(true);
            pass3_rec3.gameObject.SetActive(true);
            pass3_rec4.gameObject.SetActive(true);

            pass3_rec1.GetComponent<Renderer>().material.color = Color.red;
            pass3_rec2.GetComponent<Renderer>().material.color = Color.black;
            pass3_rec3.GetComponent<Renderer>().material.color = Color.black;
            pass3_rec4.GetComponent<Renderer>().material.color = Color.black;

            line1.gameObject.SetActive(true);
            line2.gameObject.SetActive(true);
            line3.gameObject.SetActive(true);

            pass1_panel.gameObject.SetActive(true);
            pass2_panel.gameObject.SetActive(true);
            pass3_panel.gameObject.SetActive(true);


            // Sphere.SetActive(true);
            // Sphere.GetComponent<Renderer>().material.color = new Color(0.8f, 0.2f, 0f);
            // pass1text.text = "Test";
            // isInRange = true;
        }
        else if (pos >= 8.0f && pos < 11.27f)
        {
            // pass2.enabled = true;
            // pass2.color = new Color(0.8f, 0.2f, 0.2f);
            // pass2_text.text = "Pass SUCC 62%(55/89)";
            // pass2_text.color = new Color(0.8f, 0.2f, 0.2f);
            pass2.enabled = true;
            pass2.color = new Color(0f, 0f, 0f, 0.3f);
            pass2_per.text = "62%";
            pass2_total.text = "(55/89)";
            pass2_per.color = new Color(1f, 0f, 0f);
            pass2_total.color = new Color(1f, 0f, 0f);

            pass2_rec1.gameObject.SetActive(true);
            pass2_rec2.gameObject.SetActive(true);
            pass2_rec3.gameObject.SetActive(true);
            pass2_rec4.gameObject.SetActive(true);

            pass2_rec1.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec2.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec3.GetComponent<Renderer>().material.color = Color.red;
            pass2_rec4.GetComponent<Renderer>().material.color = Color.black;

            line1.gameObject.SetActive(true);
            pass2_panel.gameObject.SetActive(true);
        }
        else
        {

            pass1.enabled = false;
            pass2.enabled = false;
            pass3.enabled = false;

            pass1_per.text = "";
            pass2_per.text = "";
            pass3_per.text = "";

            pass1_total.text = "";
            pass2_total.text = "";
            pass3_total.text = "";

            pass1_rec1.gameObject.SetActive(false);
            pass1_rec2.gameObject.SetActive(false);
            pass1_rec3.gameObject.SetActive(false);
            pass1_rec4.gameObject.SetActive(false);

            pass2_rec1.gameObject.SetActive(false);
            pass2_rec2.gameObject.SetActive(false);
            pass2_rec3.gameObject.SetActive(false);
            pass2_rec4.gameObject.SetActive(false);

            pass3_rec1.gameObject.SetActive(false);
            pass3_rec2.gameObject.SetActive(false);
            pass3_rec3.gameObject.SetActive(false);
            pass3_rec4.gameObject.SetActive(false);

            line1.gameObject.SetActive(false);
            line2.gameObject.SetActive(false);
            line3.gameObject.SetActive(false);

            pass1_panel.gameObject.SetActive(false);

            pass2_panel.gameObject.SetActive(false);
            pass3_panel.gameObject.SetActive(false);


        }



    }
}
