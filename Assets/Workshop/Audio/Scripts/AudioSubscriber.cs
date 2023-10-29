using UnityEngine;

public class AudioSubscriber : MonoBehaviour
{
    public AudioController audioController;

    private void OnEnable()
    {
        PlayerData.OnCoinIncrease += () => audioController.Play("Coin");
    }

    private void OnDisable()
    {
        PlayerData.OnCoinIncrease -= () => audioController.Play("Coin");
    }
}