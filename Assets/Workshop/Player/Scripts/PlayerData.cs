using System;
using UnityEngine;

public class PlayerData : MonoBehaviour // Componente
{
    // Valores actuales de nuestro personaje
    [Header("Stats")]
    [SerializeField] private PlayerValueFloat health;
    [SerializeField] private PlayerValueFloat mana;

    [Header("Inventory")]
    [SerializeField] private PlayerValueFloat coins;
    
    private static bool IsFirstTimeOnGame = true; // Workaround, queremos que se evalue solo la primera vez

    // Cada vez que se instance (se crea) este objeto, ejecutará el Start
    public void Awake()
    {
        if (IsFirstTimeOnGame) // Cuando se inicialice por primera vez un jugador que ejecute los Initialize y bloquee la pregunta del IF
        {
            health.Initialize();
            mana.Initialize();
            coins.Initialize();
            IsFirstTimeOnGame = false;
        }
    }

    public void IncreaseCoins(int coinsValue)
    {
        coins.Quantity += coinsValue; // coins = coins + coinsValue
    }

    public void ResetCoins()
    {
        coins.Quantity = 0;
    }

    public void ModifyHealth(float value)
    {
        health.Quantity = value;
    }
}