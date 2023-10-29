using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour 
{
    public AudioContainer[] audioContainers;

    private void Start()
    {
        for (int i = 0; i < audioContainers.Length; i++)
        {
            audioContainers[i].Create(this);
        }
    }

    public void Play(string trackName)
    {
        for (int i = 0; i < audioContainers.Length; i++)
        {
            if (trackName == audioContainers[i].trackName) // ? Busqueda por nombre de pista
            {
                Debug.Log("Sono la pista " + trackName);
                audioContainers[i].Play();
                return; // ? Termina el metodo ya que conseguimos la pista
            }
        }
    }

    public void Stop(string trackName)
    {
        for (int i = 0; i < audioContainers.Length; i++)
        {
            if (trackName == audioContainers[i].trackName) // ? Busqueda por nombre de pista
            {
                audioContainers[i].Stop();
                return; // ? Termina el metodo ya que conseguimos la pista
            }
        }
    }
}

[Serializable]
public class AudioContainer 
{
    public string trackName;
    public AudioClip track;
    public AudioMixerGroup channel;
    private AudioSource audioSource;
    private AudioController audioController;

    // TODO: Solucionar problema de instancia de AudioSource cuando cambiamos de escena
    public void Create(AudioController controller)
    {
        audioController = controller;
        audioSource = audioController.gameObject.AddComponent<AudioSource>();
        audioSource.clip = track;
        audioSource.outputAudioMixerGroup = channel;
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    public void Play()
    {
        if(audioSource == null)
            audioSource = audioController.gameObject.AddComponent<AudioSource>();

        audioSource.Play();
    }

    public void Stop()
    {
        if(audioSource == null)
            audioSource = audioController.gameObject.AddComponent<AudioSource>();
        audioSource.Stop();
    }
}