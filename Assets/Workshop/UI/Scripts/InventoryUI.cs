using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text coinText;

    public void SetCoinText(int coinsValue)
    {
        coinText.text = coinsValue.ToString();
    }
}