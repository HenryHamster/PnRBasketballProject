using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OffBallCompare : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI buttonText;
    public GameObject Image1, Image2, Image3;
    private bool isDisplay = false;

    void Start()
    {
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
    }

    // Update is called once per frame
    public void Btn_Compare()
    {
        isDisplay = !isDisplay;

        if (isDisplay)
        {
            buttonText.text = "OffBall Compare (Hide)";
            Image1.SetActive(true);
            Image2.SetActive(true);
            Image3.SetActive(true);
        }
        else
        {
            buttonText.text = "OffBall Compare (Show)";
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
        }
    }
}
