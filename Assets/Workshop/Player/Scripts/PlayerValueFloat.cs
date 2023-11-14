using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerValueFloat", menuName = "Quesillo Workshop/Player/New Player Value Float")]
public class PlayerValueFloat : ScriptableObject
{
    public enum ResetType
    {
        Default,
        ToMinQuantity,
        ToMaxQuantity
    }

    public float MinQuantity;
    public float MaxQuantity;

    public bool NoLimits;

    [SerializeField]
    private float _quantity; // Esta variable es de respaldo a la propiedad Quantity
    public float Quantity
    {
        get => _quantity;
        set
        {
            _quantity = NoLimits ? Mathf.Clamp(_quantity + value, MinQuantity, float.MaxValue) : Mathf.Clamp(_quantity + value, MinQuantity, MaxQuantity);
            OnChange?.Invoke(_quantity); // Si tiene el signo de ? es que va a preguntar si tiene un subscriptor y si no, lo ignora 
        }
    }

    public bool ResetValuesOnInitialize;
    public ResetType ResetTypeSelector;

    public event Action<float> OnChange;

    public void Initialize()
    {
        if (ResetValuesOnInitialize)
        {
            // Forma moderna de un switch
            _quantity = ResetTypeSelector switch
            {
                ResetType.Default => default,
                ResetType.ToMinQuantity => MinQuantity,
                ResetType.ToMaxQuantity => MaxQuantity,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
