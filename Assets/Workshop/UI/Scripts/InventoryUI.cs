using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text coinText;

    private void OnEnable()
    {
        PlayerData.OnCoinChange += SetCoinText; // += para suscribir
    }

    private void OnDisable()
    {
        PlayerData.OnCoinChange -= SetCoinText; // -= para desuscribir
    }

    public void SetCoinText(float coinsValue)
    {
        coinText.text = coinsValue.ToString();
    }
}