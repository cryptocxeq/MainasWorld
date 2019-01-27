using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicSwitcher : MonoBehaviour
{
    private AudioSource audioSource = null;
    [SerializeField] private AudioClip realClip = null;
    [SerializeField] private AudioClip imaginaryClip = null;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = realClip;
        audioSource.Play();

        EventManager.Instance.OnWorldChange += (world) =>
        {
            var duration = GameManager.Instance.swapper.TransitionDuration / 2;
            LeanTween
                .value(audioSource.gameObject, 1f, 0f, duration)
                .setOnUpdate((float volume) => { audioSource.volume = volume; })
                .setOnComplete(() =>
                {
                    audioSource.clip = GameManager.Instance.swapper.World == World.Real ? realClip : imaginaryClip;
                    audioSource.Play();
                    LeanTween
                        .value(audioSource.gameObject, 0f, 1f, duration)
                        .setOnUpdate((float volume) => { audioSource.volume = volume; });
                });
        };
    }
}
