using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

interface IDamageable
{
    void TakeDamage(int _damage);
    void CheckIfAlive();
}
public class PlayerHealth : MonoBehaviour , IDamageable
{
    public bool IsAlive { get; private set; }
    private int currentHealth;
    private int maxHealth = 6;

    private VideoPlayer deathClip;
    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private IFrames iframe;

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private HealthBar healthBar;
    private void Awake()
    {
        IsAlive= true;
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth; 
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator= GetComponent<Animator>();
        deathClip = GameObject.Find("DeathVideo").GetComponent<VideoPlayer>();
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfAlive();
        playerAnimator.SetTrigger("TakeDamage");
        healthBar.SetHealth(currentHealth);
        iframe = GetComponent<IFrames>();
        StartCoroutine(iframe.Invulnerability());
    }
    public void Heal(int healValue)
    {
        if(currentHealth + healValue >= maxHealth)
        {
            currentHealth= maxHealth;
        }
        else
        {
            currentHealth += healValue;
        }
        healthBar.SetHealth(currentHealth);
    }
    public void CheckIfAlive()
    {
        if (currentHealth <= 0)
        {
            IsAlive= false;
            playerAnimator.SetBool("isAlive", IsAlive);
            playerRb.bodyType = RigidbodyType2D.Static;
            deathSound.Play();
            StartCoroutine(DeathClipCoroutine());
            
        }
    }
    IEnumerator DeathClipCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        deathClip.Play();
    }
}
