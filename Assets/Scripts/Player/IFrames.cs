using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{
    private readonly float invulnerabilityTime = 1;
    private readonly int numberOfFlashes = 4;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    public IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f); // red 
            yield return new WaitForSeconds(invulnerabilityTime / (numberOfFlashes * 2)); // 0.125
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityTime / (numberOfFlashes * 2)); // 0.125
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
