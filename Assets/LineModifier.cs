using UnityEngine;

public class LineModifier : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float lineWidth = 0.1f;

    private void Start()
    {
        // 檢查是否已指定 LineRenderer 組件
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    private void Update()
    {
        // 修改線的寬度
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }
}
