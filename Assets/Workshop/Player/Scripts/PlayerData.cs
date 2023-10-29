using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour // Componente
{
    // Valores actuales de nuestro personaje
    [Header("Stats")]
    [SerializeField] private int maxHealth; // 100
    [SerializeField] private int maxStamina; // 50
    [SerializeField] private int maxMana; // 20

    [Header("Inventory")]
    [SerializeField] private PlayerValueFloat coins;

    private float _health;
    private float _stamina;
    private float _mana;

    public static Action OnCoinIncrease; // Evento de C# que puede ser usado en Unity, pero no depende del motor
    public static Action<float> OnCoinChange;

    public void Start()
    {
        OnCoinChange?.Invoke(coins.Quantity);
    }

    public void IncreaseCoins(int coinsValue)
    {
        coins.Quantity += coinsValue; // coins = coins + coinsValue
        OnCoinChange?.Invoke(coins.Quantity);
        OnCoinIncrease?.Invoke(); // ? Si OnCoinIncrease no es null (si  tiene subscriptores), invoca el evento
    }

    public void ResetCoins()
    {
        coins.Quantity = 0;
        OnCoinChange?.Invoke(coins.Quantity);
    }
}