using UnityEngine;

public class CubeHeight : MonoBehaviour
{
    // public float height; // Cube 的高度，預設為 1
    public GameObject Player;
    public GameObject Bar1, Bar2;
    private float bar2Height = 1f;
    private void Start()
    {
        // 設定 Cube 的初始高度
        Bar1.gameObject.SetActive(false);
        Bar2.gameObject.SetActive(false);
        // SetCubeHeight(height);
    }

    private void Update()
    {

        float pos = Player.transform.position.z;

        if (pos >= 11.27f && pos <= 11.72f)
        {
            float height = 0.5f;
            SetHeight(height);

        }
    }
    // 在 Update 方法中做其他操作...

    private void SetHeight(float value)
    {
        bar2Height = value;

        // 設定 Bar2 的高度
        Vector3 scale = Bar2.transform.localScale;
        scale.y = bar2Height;
        Bar2.transform.localScale = scale;

        // 調整 Bar2 的位置
        Vector3 position = Bar2.transform.position;
        position.y = bar2Height / 2f;

        Bar2.transform.position = position;

        // 取得 Cube 的 Transform 組件
        // Transform cubeTransform = transform;

        // // 根據指定的高度設定 Cube 的縮放比例
        // Vector3 scale = cubeTransform.localScale;
        // scale.y = value;
        // cubeTransform.localScale = scale;

        // // 根據指定的高度調整 Cube 的位置
        // Vector3 position = cubeTransform.position;
        // position.y = value / 2f; // 將 Cube 的位置調整到中心點
        // cubeTransform.position = position;
        Bar1.gameObject.SetActive(true);
        Bar2.gameObject.SetActive(true);

        Bar1.GetComponent<Renderer>().material.color = Color.black;
        Bar2.GetComponent<Renderer>().material.color = Color.red;

    }
}
