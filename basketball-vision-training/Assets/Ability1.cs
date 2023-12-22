using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ability1 : MonoBehaviour
{

    public TextMeshProUGUI AbilityText;
    public GameObject TextBackground;
    public GameObject Rec1, Rec2, Rec3;

    // Start is called before the first frame update
    void Start()
    {
        AbilityText.text = "C&S 30%";
        AbilityText.color = Color.black;
        TextBackground.GetComponent<Renderer>().material.color = new Color(0.5f, 0.85f, 1f, 0.6f);
        Rec1.GetComponent<Renderer>().material.color = new Color(0f, 0.6f, 0.8f);
        Rec2.GetComponent<Renderer>().material.color = Color.white;
        Rec3.GetComponent<Renderer>().material.color = Color.white;
        StartCoroutine(HideTextCoroutine());
    }
    IEnumerator HideTextCoroutine()
    {
        yield return new WaitForSeconds(6f); // 延遲兩秒

        AbilityText.gameObject.SetActive(false); // 隱藏文字
                                                 // panelImage.gameObject.SetActive = false;
        TextBackground.gameObject.SetActive(false);
        Rec1.gameObject.SetActive(false);
        Rec2.gameObject.SetActive(false);
        Rec3.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
