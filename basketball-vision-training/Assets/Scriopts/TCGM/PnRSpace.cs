using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PnRSpace : MonoBehaviour
{
    public GameObject PnR_Handler;
    public GameObject Def1, Def2;
    // public GameObject Triangle;
    // public GameObject Background;
    public GameObject line;
    // public GameObject Hint1, Hint2, Hint3;
    public TextMeshProUGUI PnR_QuailtyText;
    // public TextMeshProUGUI PnR_Area;
    public Image panelImage;
    // public Image areaImage;
    public LineRenderer lineRenderer;
    // private MeshRenderer meshRenderer;

    // public Material material;

    // private MeshFilter meshFilter;
    // private MeshRenderer meshRenderer;

    private Vector3 PnR_Handler_StartPosition = new Vector3(-1.765f, 0f, 3.960f);
    private Vector3 PnR_Handler_EndPosition = new Vector3(-2.640f, 0f, 5.4f);
    private Vector3 Def1_StartPosition = new Vector3(-1.300f, 0f, 6.963f);
    private Vector3 Def1_EndPosition = new Vector3(-1.486f, 0f, 7.1f);
    private Vector3 Def2_StartPosition = new Vector3(-4.111f, 0f, 12.36f);
    private Vector3 Def2_EndPostion = new Vector3(-4.20f, 0f, 12.36f);
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = 4;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.useWorldSpace = true;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        lineRenderer.enabled = false;
        //Triangle.gameObject.SetActive(false);
        // Hint1.gameObject.SetActive(true);
        // Hint2.gameObject.SetActive(true);
        // Hint3.gameObject.SetActive(true);
        // Background.gameObject.SetActive(false);
        line.SetActive(false);
        // panelImage.enabled = true;
        panelImage.color = new Color(1f, 1f, 1f, 0f);
        // // NEW ADD
        // Mesh mesh = new Mesh();

        // // // Set the vertices of the triangle based on the positions of the gameObjects
        // Vector3[] vertices = new Vector3[3];
        // vertices[0] = PnR_Handler.transform.position;
        // vertices[1] = Def1.transform.position;
        // vertices[2] = Def2.transform.position;
        // mesh.vertices = vertices;

        // // // Set the indices of the triangle
        // int[] indices = new int[] { 0, 1, 2 };
        // mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        // // // Create a new mesh renderer and assign the mesh and material to it
        // meshFilter = gameObject.AddComponent<MeshFilter>();
        // meshRenderer = gameObject.AddComponent<MeshRenderer>();
        // meshFilter.mesh = mesh;
        // meshRenderer.material = material;

        // Disable the mesh renderer initially
        //  meshRenderer.enabled = false;


    }

    // Update is called once per frame
    private void Update()
    {
        bool HanlderInArea = PnR_Handler.transform.position.z >= PnR_Handler_StartPosition.z && PnR_Handler.transform.position.z <= PnR_Handler_EndPosition.z;
        // 檢查 O6 是否進入特定範圍
        bool Def1InArea = Def1.transform.position.z >= Def1_StartPosition.z && Def1.transform.position.z <= Def1_EndPosition.z;
        bool Def2InArea = Def2.transform.position.x <= Def2_StartPosition.x && Def2.transform.position.x >= Def2_EndPostion.x;

        // if (PnR_Handler.transform.position.z <= PnR_Handler_EndPosition.z)
        // {
        //     Hint1.gameObject.SetActive(true);
        //     Hint2.gameObject.SetActive(true);
        //     Hint3.gameObject.SetActive(true);

        // }
        // else
        // {
        //     Hint1.gameObject.SetActive(false);
        //     Hint2.gameObject.SetActive(false);
        //     Hint3.gameObject.SetActive(false);
        // }

        if (HanlderInArea && Def1InArea && Def2InArea)
        {
            // The 3 player are all in the specific area.
            // IsBallHanderIn = true;
            // Is_D1_In = true;
            // Is_D2_In = true;

            // Vector3 pos1 = PnR_Handler.transform.position;
            // Vector3 pos2 = Def1.transform.position;
            // Vector3 pos3 = Def2.transform.position;

            // Vector3[] positions = new Vector3[] { pos1, pos2, pos3 };
            // lineRenderer.positionCount = 4;
            // lineRenderer.SetPosition(0, pos1);
            // lineRenderer.SetPosition(1, pos2);
            // lineRenderer.SetPosition(2, pos3);
            // lineRenderer.SetPosition(3, pos1);
            // lineRenderer.enabled = true;

            // NEW ADD START
            // Mesh mesh = meshFilter.mesh;
            // Vector3[] vertices = new Vector3[3];
            // vertices[0] = PnR_Handler.transform.position;
            // vertices[1] = Def1.transform.position;
            // vertices[2] = Def2.transform.position;
            // mesh.vertices = vertices;
            // int[] indices = new int[] { 0, 1, 2 };
            // mesh.SetIndices(indices, MeshTopology.Triangles, 0);

            // // Enable the mesh renderer to make the triangle visible
            // meshRenderer.enabled = true;

            // NEW ADD END

            CalculateSpace();
            //Triangle.gameObject.SetActive(true);
            // Background.gameObject.SetActive(true);
            // panelImage.enabled = true;
            panelImage.color = new Color(0.6f, 0.93f, 0.56f, 0.3f);
            PnR_QuailtyText.text = "Good Space";
            PnR_QuailtyText.color = Color.black;

            //ackground.color = new Color(0.6f, 0.93f, 0.56f, 0.78f);
            line.SetActive(true);


        }
        else
        {
            //PnR_Area.text = "";
            PnR_QuailtyText.text = "";
            // meshRenderer.enabled = false;
            lineRenderer.enabled = false;
            //Triangle.gameObject.SetActive(false);
            // Background.gameObject.SetActive(false);
            line.SetActive(false);
            //panelImage.enabled = false;
            panelImage.color = new Color(1f, 1f, 1f, 0f);
        }
    }
    private void CalculateSpace()
    {

        float x1_Diff = (PnR_Handler.transform.position.x - Def1.transform.position.x) * (50f / 15f);
        float z1_Diff = (PnR_Handler.transform.position.z - Def1.transform.position.z) * (92f / 28f);
        float distance1 = Mathf.Sqrt(Mathf.Pow(x1_Diff, 2) + Mathf.Pow(z1_Diff, 2));

        float x2_Diff = (PnR_Handler.transform.position.x - Def2.transform.position.x) * (50f / 15f);
        float z2_Diff = (PnR_Handler.transform.position.z - Def2.transform.position.z) * (92f / 28f);
        float distance2 = Mathf.Sqrt(Mathf.Pow(x2_Diff, 2) + Mathf.Pow(z2_Diff, 2));

        float x3_Diff = (Def1.transform.position.x - Def2.transform.position.x) * (50f / 15f);
        float z3_Diff = (Def1.transform.position.z - Def2.transform.position.z) * (92f / 28f);
        float distance3 = Mathf.Sqrt(Mathf.Pow(x3_Diff, 2) + Mathf.Pow(z3_Diff, 2));

        float s = (distance1 + distance2 + distance3) / 2;

        float space = Mathf.Sqrt(s * (s - distance1) * (s - distance2) * (s - distance3));
        // Debug.Log("Distance between T4 and O6: " + distance.ToString("F2"));
        // PnR_Area.SetText("Area" + space.ToString("F2") + "ft^2");
        //         PnR_Area.color = new Color(0f, 0.4f, 0f, 1f);
        //PnR_Area.color = new Color(1f, 0f, 0f);
    }

}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
// public class PnRSpace : MonoBehaviour
// {
//     // public GameObject PnR_Handler;
//     // public GameObject Def1;
//     // public GameObject Def2;

//     private MeshFilter meshFilter;
//     private MeshRenderer meshRenderer;
//     public Material material;


//     public GameObject PnR_Handler;
//     public GameObject Def1, Def2;
//     public GameObject Triangle;
//     public GameObject Background;
//     public GameObject Hint1, Hint2, Hint3;
//     public TextMeshProUGUI PnR_QuailtyText;
//     public TextMeshProUGUI PnR_Area;
//     public Image panelImage;
//     // public Image areaImage;
//     public LineRenderer lineRenderer;
//     // private MeshRenderer meshRenderer;

//     // private Vector3 PnR_Handler_StartPosition = new Vector3(-1.765f, 0f, 3.960f);
//     // private Vector3 PnR_Handler_EndPosition = new Vector3(-2.640f, 0f, 5.4f);
//     // private Vector3 Def1_StartPosition = new Vector3(-1.300f, 0f, 6.963f);
//     // private Vector3 Def1_EndPosition = new Vector3(-1.486f, 0f, 7.1f);
//     // private Vector3 Def2_StartPosition = new Vector3(-4.111f, 0f, 12.36f);
//     // private Vector3 Def2_EndPostion = new Vector3(-4.20f, 0f, 12.36f);

//     private void Awake()
//     {

//     }

//     private void Start()
//     {
//         Triangle.gameObject.SetActive(false);
//         Hint1.gameObject.SetActive(true);
//         Hint2.gameObject.SetActive(true);
//         Hint3.gameObject.SetActive(true);
//         Background.gameObject.SetActive(false);

//         // meshFilter = GetComponent<MeshFilter>();
//         // meshRenderer = GetComponent<MeshRenderer>();
//         // Mesh mesh = new Mesh();

//         // // 创建红色材质
//         // Material redMaterial = new Material(Shader.Find("UI/Default"));

//         // // 分配材质给Mesh Renderer
//         // meshRenderer.material = redMaterial;

//         Mesh mesh = new Mesh();

//         // Set the vertices of the triangle based on the positions of the gameObjects
//         Vector3[] vertices = new Vector3[3];
//         vertices[0] = PnR_Handler.transform.position;
//         vertices[1] = Def1.transform.position;
//         vertices[2] = Def2.transform.position;
//         mesh.vertices = vertices;

//         // Set the indices of the triangle
//         int[] indices = new int[] { 0, 1, 2 };
//         mesh.SetIndices(indices, MeshTopology.Triangles, 0);

//         // Create a new mesh renderer and assign the mesh and material to it
//         meshFilter = gameObject.AddComponent<MeshFilter>();
//         meshRenderer = gameObject.AddComponent<MeshRenderer>();
//         meshFilter.mesh = mesh;
//         meshRenderer.material = material;

//     }


//     private void Update()
//     {
//         bool handlerInArea = PnR_Handler.transform.position.z >= 3.960f && PnR_Handler.transform.position.z <= 5.4f;
//         bool def1InArea = Def1.transform.position.z >= 6.963f && Def1.transform.position.z <= 7.1f;
//         bool def2InArea = Def2.transform.position.x <= -4.111f && Def2.transform.position.x >= -4.20f;

//         if (handlerInArea)
//         {
//             Hint1.gameObject.SetActive(true);
//             Hint2.gameObject.SetActive(true);
//             Hint3.gameObject.SetActive(true);

//         }
//         else
//         {
//             Hint1.gameObject.SetActive(false);
//             Hint2.gameObject.SetActive(false);
//             Hint3.gameObject.SetActive(false);
//             //         }

//             if (handlerInArea && def1InArea && def2InArea)
//             {
//                 Mesh mesh = meshFilter.mesh;
//                 Vector3[] vertices = new Vector3[3];
//                 vertices[0] = PnR_Handler.transform.position;
//                 Debug.Log("T4 position is " + vertices[0]);
//                 vertices[1] = Def1.transform.position;
//                 vertices[2] = Def2.transform.position;
//                 mesh.vertices = vertices;


//                 Vector3 positionA = PnR_Handler.transform.position;
//                 Vector3 positionB = Def1.transform.position;
//                 Vector3 positionC = Def2.transform.position;

//                 // Mesh mesh = CreateTriangleMesh(positionA, positionB, positionC);
//                 //meshFilter.mesh = mesh;

//                 CalculateSpace();
//                 Triangle.gameObject.SetActive(true);
//                 Background.gameObject.SetActive(true);

//                 PnR_QuailtyText.text = "Good PnR";
//                 PnR_QuailtyText.color = new Color(1f, 0f, 0f);
//             }
//             else
//             {
//                 meshFilter.mesh = null;
//             }
//         }
//     }

//     private void CalculateSpace()
//     {

//         float x1_Diff = (PnR_Handler.transform.position.x - Def1.transform.position.x) * (50f / 15f);
//         float z1_Diff = (PnR_Handler.transform.position.z - Def1.transform.position.z) * (92f / 28f);
//         float distance1 = Mathf.Sqrt(Mathf.Pow(x1_Diff, 2) + Mathf.Pow(z1_Diff, 2));

//         float x2_Diff = (PnR_Handler.transform.position.x - Def2.transform.position.x) * (50f / 15f);
//         float z2_Diff = (PnR_Handler.transform.position.z - Def2.transform.position.z) * (92f / 28f);
//         float distance2 = Mathf.Sqrt(Mathf.Pow(x2_Diff, 2) + Mathf.Pow(z2_Diff, 2));

//         float x3_Diff = (Def1.transform.position.x - Def2.transform.position.x) * (50f / 15f);
//         float z3_Diff = (Def1.transform.position.z - Def2.transform.position.z) * (92f / 28f);
//         float distance3 = Mathf.Sqrt(Mathf.Pow(x3_Diff, 2) + Mathf.Pow(z3_Diff, 2));

//         float s = (distance1 + distance2 + distance3) / 2;

//         float space = Mathf.Sqrt(s * (s - distance1) * (s - distance2) * (s - distance3));
//         // Debug.Log("Distance between T4 and O6: " + distance.ToString("F2"));
//         PnR_Area.SetText("Area" + space.ToString("F2") + "ft^2");
//         //         PnR_Area.color = new Color(0f, 0.4f, 0f, 1f);
//         PnR_Area.color = new Color(1f, 0f, 0f);
//     }

//     // private Mesh CreateTriangleMesh(Vector3 positionA, Vector3 positionB, Vector3 positionC)
//     // {
//     //     Mesh mesh = new Mesh();

//     //     // 顶点坐标
//     //     Vector3[] vertices = new Vector3[3]
//     //     {
//     //         positionA,
//     //         positionB,
//     //         positionC
//     //     };
//     //     mesh.vertices = vertices;

//     //     // 三角形索引
//     //     int[] triangles = new int[3] { 0, 1, 2 };
//     //     mesh.triangles = triangles;

//     //     return mesh;
//     // }
// }
