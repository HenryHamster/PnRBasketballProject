using UnityEngine;

public class BarChart : MonoBehaviour
{
    public Renderer cubeRenderer;
    public float fillPercentage = 0.5f;

    private void Start()
    {
        // 確保 Renderer 存在於 Cube 上
        if (cubeRenderer == null)
        {
            cubeRenderer = GetComponent<Renderer>();
        }

        // 設定初始顏色
        SetCubeColor(fillPercentage);
    }

    private void Update()
    {
        // 在適當的時機更新 fillPercentage
        // fillPercentage 的值範圍應該在 0 到 1 之間
        // 例如根據使用者輸入或其他邏輯來設定 fillPercentage 的值
        fillPercentage = 0.7f;

        // 根據新的 fillPercentage 更新顏色
        SetCubeColor(fillPercentage);
    }

    private void SetCubeColor(float fillPercentage)
    {
        // 計算紅色和黑色的比例
        float redPercentage = Mathf.Clamp01(fillPercentage);
        float blackPercentage = 1f - redPercentage;

        // 取得原先的材質
        Material[] originalMaterials = cubeRenderer.sharedMaterials;

        // 創建紅色和黑色材質
        Material redMaterial = new Material(Shader.Find("Custom/RedBlackShader"));
        redMaterial.color = Color.red;
        Material blackMaterial = new Material(Shader.Find("Custom/RedBlackShader"));
        blackMaterial.color = Color.black;

        // 設定材質
        Material[] materials = new Material[2];
        materials[0] = redMaterial;
        materials[1] = blackMaterial;
        cubeRenderer.materials = materials;

        // 設定紅色和黑色的比例
        redMaterial.SetFloat("_Proportion", redPercentage);
        blackMaterial.SetFloat("_Proportion", blackPercentage);
    }
}
