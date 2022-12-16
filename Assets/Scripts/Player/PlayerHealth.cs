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
    private int _currentHealth;
    private int _maxHealth = 6;

    private VideoPlayer _deathClip;
    private HealthBar _healthBar;
    private Animator _playerAnimator;
    private Rigidbody2D _playerRb;
    private IFrames _iframe;

    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private HealthBar healthBar;
    private void Awake()
    {
        IsAlive= true;
        healthBar.SetMaxHealth(_maxHealth);
        _currentHealth = _maxHealth; 
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator= GetComponent<Animator>();
        _deathClip = GameObject.Find("DeathVideo").GetComponent<VideoPlayer>();
    }
    

    public void TakeDamage(int _damage)
    {
        _currentHealth -= _damage;
        CheckIfAlive();
        _playerAnimator.SetTrigger("TakeDamage");
        healthBar.SetHealth(_currentHealth);
        _iframe = GetComponent<IFrames>();
        StartCoroutine(_iframe.Invulnerability());
    }
    public void Heal(int _healValue)
    {
        if(_currentHealth + _healValue >= _maxHealth)
        {
            _currentHealth= _maxHealth;
        }
        else
        {
            _currentHealth += _healValue;
        }
        healthBar.SetHealth(_currentHealth);
    }
    public void CheckIfAlive()
    {
        if (_currentHealth <= 0)
        {
            IsAlive= false;
            _playerAnimator.SetBool("isAlive", IsAlive);
            _playerRb.bodyType = RigidbodyType2D.Static;
            _deathSound.Play();
            StartCoroutine(DeathClipCoroutine());
            
        }
    }
    IEnumerator DeathClipCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _deathClip.Play();
    }
}
