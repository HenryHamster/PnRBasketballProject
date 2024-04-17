using UnityEngine;

/*

以下這是為了 Switch 寫的 Pseudo Code

using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject o3;
    public GameObject t5;
    public float distance = 5f;
    public string displayText = "5FT";
    public Color lineColor = Color.white;
    public Font font;
    public int fontSize = 14;
    public string textToShow = "掩護品質：良好"; // 顯示的文字
    public Color backgroundColor = Color.green; // 背景顏色

    private Text textComponent;
    private RectTransform rectTransform;

    private Vector3 o3Pos;
    private Vector3 t5Pos;
    private LineRenderer lineRenderer;
    private GameObject textObject;
    private TextMesh textMesh;

    void Start()
    {
        o3Pos = o3.transform.position;
        t5Pos = t5.transform.position;
        
        // 這是要抓 Unity 中的 Text & 長方形的 Component 
        textComponent = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();

        // 這是要畫 O3 & T5 的線條
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, o3Pos);
        lineRenderer.SetPosition(1, t5Pos);

        textObject = new GameObject();
        textObject.transform.position = (o3Pos + t5Pos) / 2f;
        textObject.transform.LookAt(Camera.main.transform);
        textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = displayText;
        textMesh.fontSize = fontSize;
        textMesh.font = font;
        textMesh.color = lineColor;
    }

    void Update()
    {
        o3Pos = o3.transform.position;
        t5Pos = t5.transform.position;

        if (o3Pos.x == 1 && o3Pos.y == 0 && o3Pos.z == 0 &&
            t5Pos.x == 1 && t5Pos.y == 1 && t5Pos.z == 0)
        {
            // 設定文字和背景顏色
            textComponent.text = textToShow;
            textComponent.color = Color.white;
            rectTransform.GetComponent<Image>().color = backgroundColor;

            // 顯示線條與對應的文字內容
            lineRenderer.enabled = true;
            textObject.SetActive(true);

            lineRenderer.SetPosition(0, o3Pos);
            lineRenderer.SetPosition(1, t5Pos);

            textObject.transform.position = (o3Pos + t5Pos) / 2f;
            textObject.transform.LookAt(Camera.main.transform);
        }
        else
        {
            // 隱藏線條與對應內容
            lineRenderer.enabled = true;
            textObject.SetActive(true);

            // 隱藏文字和背景
            textComponent.text = "";
            rectTransform.GetComponent<Image>().color = Color.clear;
        }
        
        
    }
}

*/
