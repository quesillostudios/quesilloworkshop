using UnityEngine;

public class AudioSubscriber : MonoBehaviour
{
    public AudioController audioController;

    // TODO: adaptar el audio al nuevo sistema de scriptable
    private void OnEnable()
    {
        //PlayerData.OnCoinIncrease += () => audioController.Play("Coin");
    }

    private void OnDisable()
    {
        //PlayerData.OnCoinIncrease -= () => audioController.Play("Coin");
    }
}