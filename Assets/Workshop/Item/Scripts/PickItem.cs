using Unity.VisualScripting;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private Item Item;

    private void Start()
    {
        Item = GetComponent<Item>();
    }
    
    private void OnTriggerEnter(Collider other) // Other es cualquier cosa que choque con este componente
    {
        if (other.gameObject.CompareTag("Player"))
            if(Item.IsPickable) 
                Item.TryPick(other);
    }
}