using System;
using UnityEngine;
using UnityEngine.UI;

public class StatusHUD : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider ManaSlider;

    public PlayerValueFloat Health;
    public PlayerValueFloat Mana;

    private void OnEnable()
    {
        Health.OnChange += OnHealthChange;
        Mana.OnChange += OnManaChange;
    }

    private void OnDisable()
    {
        Health.OnChange -= OnHealthChange;
        Mana.OnChange -= OnManaChange;
    }

    private void OnHealthChange(float health)
    {
        HealthSlider.value = MathExtra.PercentMax(health, Health.MaxQuantity);
    }

    private void OnManaChange(float mana)
    {
        ManaSlider.value = MathExtra.PercentMax(mana, Mana.MaxQuantity);
    }
}
