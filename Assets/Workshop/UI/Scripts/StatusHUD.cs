using System;
using UnityEngine;
using UnityEngine.UI;

public class StatusHUD : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider ManaSlider;

    private void OnEnable()
    {
        PlayerData.OnStatsInitialized += Configure;
        PlayerData.OnHealthChange += OnHealthChange;
        PlayerData.OnManaChange += OnManaChange;
    }

    private void OnDisable()
    {
        PlayerData.OnStatsInitialized -= Configure;
        PlayerData.OnHealthChange -= OnHealthChange;
        PlayerData.OnManaChange -= OnManaChange;
    }

    private void Configure(PlayerValueFloat health, PlayerValueFloat mana)
    {
        HealthSlider.minValue = health.MinQuantity;
        HealthSlider.maxValue = health.MaxQuantity;

        ManaSlider.minValue = mana.MinQuantity;
        ManaSlider.maxValue = mana.MaxQuantity;
    }

    private void OnHealthChange(float health)
    {
        HealthSlider.value = health;
    }

    private void OnManaChange(float mana)
    {
        ManaSlider.value = mana;
    }
}
