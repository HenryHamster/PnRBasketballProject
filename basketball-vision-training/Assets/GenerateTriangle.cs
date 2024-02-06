using UnityEngine;
using System;
using System.Collections;
[RequireComponent(typeof(MeshFilter))]
public class GenerateTriangle : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject GoodSpaceText;
    // public Material material;
    Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector3 PnR_Handler_StartPosition = new Vector3(-1.765f, 0f, 3.960f);
    private Vector3 PnR_Handler_EndPosition = new Vector3(-2.640f, 0f, 5.4f);
    private Vector3 Def1_StartPosition = new Vector3(-1.300f, 0f, 6.963f);
    private Vector3 Def1_EndPosition = new Vector3(-1.486f, 0f, 7.1f);
    private Vector3 Def2_StartPosition = new Vector3(-4.111f, 0f, 12.36f);
    private Vector3 Def2_EndPostion = new Vector3(-4.20f, 0f, 12.36f);

    // private MeshFilter meshFilter;
    // private MeshRenderer meshRenderer;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    private void Start()
    {
        // Create a new mesh
        // Mesh mesh = new Mesh();

        // MakeMeshData();
        // CreateMesh();

        // Set the vertices of the triangle based on the positions of the gameObjects
        // Vector3[] vertices = new Vector3[3];
        // vertices[0] = objectA.transform.position;
        // vertices[1] = objectB.transform.position;
        // vertices[2] = objectC.transform.position;
        // mesh.vertices = vertices;

        // // Set the indices of the triangle
        // int[] indices = new int[] { 0, 1, 2 };
        // mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        // // Create a new mesh renderer and assign the mesh and material to it
        // meshFilter = gameObject.AddComponent<MeshFilter>();
        // meshRenderer = gameObject.AddComponent<MeshRenderer>();
        // meshFilter.mesh = mesh;
        // meshRenderer.material = material;
    }
    int CustomSort(Vector3 a, Vector3 b)
    {
        return b.z.CompareTo(a.z);
    }
    void MakeMeshData()
    {
        Debug.Log(objectA.transform.position);
        
        vertices = new Vector3[] { objectA.transform.position, objectB.transform.position, objectC.transform.position };

        Array.Sort(vertices, CustomSort);
        // vertices = new Vector3[] { objectA.transform.position, new Vector3(0, 0, 1), new Vector3(0, 0, 2) };
        triangles = new int[] { 0, 1, 2 };

    }
    // private void FixedUpdate()
    // {
    //     // Update the vertices of the triangle based on the current positions of the gameObjects
    //     Mesh mesh = meshFilter.mesh;
    //     Vector3[] vertices = new Vector3[3];
    //     vertices[0] = objectA.transform.position;
    //     Debug.Log("T4 position is " + vertices[0]);
    //     vertices[1] = objectB.transform.position;
    //     vertices[2] = objectC.transform.position;
    //     mesh.vertices = vertices;
    // }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
    }

    void Update()
    {
        bool HanlderInArea = objectA.transform.position.z >= PnR_Handler_StartPosition.z && objectA.transform.position.z <= PnR_Handler_EndPosition.z;
        // 檢查 O6 是否進入特定範圍
        bool Def1InArea = objectC.transform.position.z >= Def1_StartPosition.z && objectC.transform.position.z <= Def1_EndPosition.z;
        bool Def2InArea = objectB.transform.position.x <= Def2_StartPosition.x && objectB.transform.position.x >= Def2_EndPostion.x;
        if (/**/true ||/**/HanlderInArea && Def1InArea && Def2InArea)
        {
            MakeMeshData();
            CreateMesh();
            mesh.RecalculateNormals();
            GoodSpaceText.SetActive(true);
        }
        else
        {

            GoodSpaceText.SetActive(false);
            mesh.Clear();
        }
    }
}
