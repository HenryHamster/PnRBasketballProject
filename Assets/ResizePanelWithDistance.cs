using UnityEngine;

public class ResizePanelWithDistance : MonoBehaviour
{
    public Transform targetObject; // 要計算距離的目標物體
    public GameObject panel; // 要調整大小的 Panel

    public float minDistance = 1.0f; // 最小距離時的 Panel 大小
    public float maxDistance = 10.0f; // 最大距離時的 Panel 大小
    public float target_scale = 1.0f;

    private void Update()
    {
        // 計算 Panel 與目標物體之間的距離
        float distance = Vector3.Distance(panel.transform.position, targetObject.position);
        //Debug.Log(distance);

        // 將距離限制在最小和最大值之間
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // 根據距離來計算 Panel 的縮放比例
        float scale = 0.02f * Mathf.Lerp(1.0f, target_scale, (distance - minDistance) / (maxDistance - minDistance));

        // 設定 Panel 的縮放
        panel.transform.localScale = new Vector3(scale, scale, 1.0f);
    }
}
