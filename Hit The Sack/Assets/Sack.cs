using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sack : MonoBehaviour
{
    /*
    SpriteRenderer spriteRenderer;

    [Range(0f, 1f)]
    public float fadeToRedAmount = 0f;

    public float fadingSpeed = 0.5f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Color c = spriteRenderer.color;

        c.g = 1f;
        c.b = 1f;

        spriteRenderer.material.color = c;

    }
    IEnumerator FadeToRed()
    {
        for(float i = 1f; i >= fadeToRedAmount; i -= 0.05f)
        {
            Color c = spriteRenderer.material.color;

            c.g = i;
            c.b = i;

            spriteRenderer.material.color = c;

            yield return new WaitForSeconds(fadingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            StartCoroutine(FadeToRed());
        }
    }
    */
}
