using UnityEngine;
using UnityEngine.Events;

public class PickItem : MonoBehaviour
{
    public UnityEvent<string> obtainedCoin;

    private void OnTriggerEnter(Collider other) // Other es cualquier cosa que choque con este componente
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerData obtainedPlayerData = other.gameObject.GetComponent<PlayerData>();
            obtainedPlayerData.IncreaseCoins(1);

            obtainedCoin.Invoke("Coin"); // Llamar o emitir la señal que la moneda se obtuvo

            gameObject.SetActive(false); // Apagar un objeto de la escena
        }
    }
}