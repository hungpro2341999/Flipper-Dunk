using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBG : MonoBehaviour
{
    public float scaleX;
    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        var xScale = cameraSize.x / spriteSize.x;
        var yScale = cameraSize.y / spriteSize.y;
        scaleX = xScale;
        scale = new Vector2(xScale, yScale);

        transform.position = Vector2.zero; // Optional
        transform.localScale = scale;

    }
}
