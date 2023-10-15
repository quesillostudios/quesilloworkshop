using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public bool IsPickable;

    public virtual void TryPick(Collider possiblePlayer)
    {
        Debug.Log($"[Item] {possiblePlayer.name} esta intentando tomar el objeto");
    }
}