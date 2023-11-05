using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour // Componente
{
    // Valores actuales de nuestro personaje
    [Header("Stats")]
    [SerializeField] private PlayerValueFloat health;
    [SerializeField] private PlayerValueFloat mana;

    [Header("Inventory")]
    [SerializeField] private PlayerValueFloat coins;

    // TODO: solucionar o reducir estas variables estaticas, solo dejar las realmente importantes
    public static Action<PlayerValueFloat, PlayerValueFloat> OnStatsInitialized; // TODO: hacer una mejor implementación
    
    public static Action OnCoinIncrease; // Evento de C# que puede ser usado en Unity, pero no depende del motor
    public static Action<float> OnCoinChange;
    
    public static Action<float> OnHealthChange;
    public static Action<float> OnManaChange;
    
    private static bool IsFirstTimeOnGame = true; // Workaround, queremos que se evalue solo la primera vez

    // Cada vez que se instance (se crea) este objeto, ejecutará el Start
    public void Start()
    {
        if (IsFirstTimeOnGame) // Cuando se inicialice por primera vez un jugador que ejecute los Initialize y bloquee la pregunta del IF
        {
            health.Initialize();
            mana.Initialize();
            coins.Initialize();
            IsFirstTimeOnGame = false;
        }
        
        OnStatsInitialized?.Invoke(health, mana);
        OnHealthChange?.Invoke(health.Quantity);
        OnManaChange?.Invoke(mana.Quantity);
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