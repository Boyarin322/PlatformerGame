using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        fill.color = gradient.Evaluate(1f); 
    }
    public void SetHealth(int currHealth)
    {
        healthSlider.value = currHealth;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
   
   

}
