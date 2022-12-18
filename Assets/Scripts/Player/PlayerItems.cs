using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private int coinAmount;
    
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Awake()
    {
        coinAmount = PlayerPrefs.GetInt("CoinsAmount", 0);
        coinsText.text = $"<sprite=0> : {coinAmount}";
    }
    public void AddCoins(int coinsToAdd)
    {
        PlayerPrefs.SetInt("CoinsAmount", coinAmount += coinsToAdd);
        coinAmount = PlayerPrefs.GetInt("CoinsAmount", 0);
        coinsText.text = $"<sprite=0> : {coinAmount}";
    }
}
