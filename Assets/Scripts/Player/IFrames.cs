using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrames : MonoBehaviour
{
    private readonly float _invulnerabilityTime = 1;
    private readonly int _numberOfFlashes = 4;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    public IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < _numberOfFlashes; i++)
        {
            _spriteRenderer.color = new Color(1, 0, 0, 0.5f); // red 
            yield return new WaitForSeconds(_invulnerabilityTime / (_numberOfFlashes * 2)); // 0.125
            _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(_invulnerabilityTime / (_numberOfFlashes * 2)); // 0.125
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
