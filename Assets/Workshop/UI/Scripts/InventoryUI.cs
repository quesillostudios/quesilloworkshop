using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text coinText;
    public PlayerValueFloat Coins;

    private void OnEnable()
    {
        Coins.OnChange += SetCoinText; // += para suscribir
    }

    private void OnDisable()
    {
        Coins.OnChange -= SetCoinText; // -= para desuscribir
    }

    private void SetCoinText(float coinsValue)
    {
        coinText.text = coinsValue.ToString();
    }
}