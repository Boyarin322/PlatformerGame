using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private int _coinAmount;
    
    [SerializeField] private TextMeshProUGUI _coinsHud;

    private void Awake()
    {
        _coinAmount = PlayerPrefs.GetInt("CoinsAmount", 0);
        _coinsHud.text = $"<sprite=0> : {_coinAmount}";
    }
    public void AddCoins(int coinsToAdd)
    {
        PlayerPrefs.SetInt("CoinsAmount", _coinAmount += coinsToAdd);
        _coinAmount = PlayerPrefs.GetInt("CoinsAmount", 0);
        _coinsHud.text = $"<sprite=0> : {_coinAmount}";
    }
}
