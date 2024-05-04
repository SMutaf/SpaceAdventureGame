using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEffectScript : MonoBehaviour
{
    public float objectSpeed = 1f;
    public float alphaChangeSpeed = 1f;
    public float scaleChangeSpeed = 1f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        TranslateObject();

        AlphaChange();

        ScaleChange();
    }

    void AlphaChange()
    {
        Color alpha = spriteRenderer.material.color;
        alpha.a -= alphaChangeSpeed * Time.deltaTime;

        if (alpha.a < 0f)
            Destroy(this.gameObject);

        spriteRenderer.material.color = alpha;
    }

    void TranslateObject()
    {
        Vector3 Movement = new Vector3(0f, -objectSpeed, 0f) * Time.deltaTime;
        transform.Translate(Movement);
    }

    void ScaleChange()
    {
        Vector3 newScale = new Vector3(this.transform.localScale.x + scaleChangeSpeed * Time.deltaTime, transform.localScale.y, 1);

        this.transform.localScale = newScale;
    }
}
