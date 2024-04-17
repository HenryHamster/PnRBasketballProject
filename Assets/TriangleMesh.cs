using UnityEngine;

public class TriangleMesh : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();

        // 定义三角形的顶点坐标
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0f, 0f, 0f);
        vertices[1] = new Vector3(1f, 0f, 0f);
        vertices[2] = new Vector3(0.5f, 1f, 0f);

        // 定义三角形的顶点索引
        int[] triangles = new int[3] { 0, 1, 2 };

        // 设置Mesh的顶点和三角形索引
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // 计算法线和切线（可选）
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        // 分配Mesh给MeshFilter组件
        meshFilter.mesh = mesh;
    }
}
