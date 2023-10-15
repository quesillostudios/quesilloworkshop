using UnityEngine;

public class PickItem : MonoBehaviour
{
    public Item Item;
    
    private void OnTriggerEnter(Collider other) // Other es cualquier cosa que choque con este componente
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Item.TryPick(other);
        }
    }
}