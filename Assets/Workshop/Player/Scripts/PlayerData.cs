using UnityEngine;

public class PlayerData : MonoBehaviour // Componente
{
    // Valores actuales de nuestro personaje
    [Header("Stats")]
    [SerializeField] private int maxHealth; // 100
    [SerializeField] private int maxStamina; // 50
    [SerializeField] private int maxMana; // 20

    [Header("Inventory")]
    [SerializeField] private int coins;

    [Header("UI")]
    [SerializeField] private InventoryUI inventoryUI;

    private float _health;
    private float _stamina;
    private float _mana;

    public void IncreaseCoins(int coinsValue)
    {
        coins += coinsValue; // coins = coins + coinsValue
        inventoryUI.SetCoinText(coins);
    }

    public void ResetCoins()
    {
        coins = 0;
    }
}