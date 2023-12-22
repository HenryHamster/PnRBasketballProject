using UnityEngine;

public class BarHeight : MonoBehaviour
{
    public float heightScale = 0.5f; // 用户设置的高度缩放比例
    private float originalHeight; // 原始 Cube 的高度
    private float originX, originZ;
    private void Start()
    {
        // 获取 Cube 的初始高度
        originalHeight = transform.localScale.y;
        originX = transform.localScale.x;
        originZ = transform.localScale.z;
    }

    private void Update()
    {
        // 根据用户设置的高度缩放比例调整 Cube 的高度
        float adjustedHeight = originalHeight * heightScale;

        // 设置 Cube 的 Y 轴缩放
        transform.localScale = new Vector3(originX, adjustedHeight, originZ);
    }
}
