using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 position = transform.position;
        // 這裡到時候會給與特定位置，然後顯示對應的圖表內容。
        if (position.x > 0)
        {
            spriteRenderer.sprite = image1;
        }
        else
        {
            spriteRenderer.sprite = image2;
        }
    }
}
