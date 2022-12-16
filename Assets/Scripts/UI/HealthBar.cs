using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    public void SetMaxHealth(int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;

        _fill.color = _gradient.Evaluate(1f); 
    }
    public void SetHealth(int currHealth)
    {
        _healthSlider.value = currHealth;
        _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
    }
   
   

}
