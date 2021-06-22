using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Health))]
public class ImpactAudio : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent[] audioEvent;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        var health = GetComponent<Health>();
        health.OnTookHit += ImpactAudio_OnTookHit;
        health.OnDied += ImpactAudio_OnDied; 
    }

    private void ImpactAudio_OnDied()
    {
        audioEvent[1].Play(audioSource);
    }

    private void ImpactAudio_OnTookHit()
    {
        audioEvent[0].Play(audioSource);
    }

}
