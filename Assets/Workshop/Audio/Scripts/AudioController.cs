using UnityEngine;
using System;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class AudioController : MonoBehaviour 
{
    public AudioContainer[] audioContainers;

    private void Awake()
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

    public void Create(AudioController controller)
    {
        audioSource = controller.AddComponent<AudioSource>();
        audioSource.clip = track;
        audioSource.outputAudioMixerGroup = channel;
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    } 

    public void Play()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}