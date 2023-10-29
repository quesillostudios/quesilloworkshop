using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int CoinValue;
    
    public override void TryPick(Collider possiblePlayer)
    {
        PlayerData playerData = possiblePlayer.GetComponent<PlayerData>();

        if (playerData == null) return; // Si el jugador no tiene PlayerData se rompe la funcion, no se ejecuta lo de abajo
        
        // El codigo que funcionara si existe PlayerData
        playerData.IncreaseCoins(CoinValue);
        gameObject.SetActive(false); // Cuando se obtenga se apaga
    }
}
