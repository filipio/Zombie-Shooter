using UnityEngine;

public class OnEnterAreaExplosion : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private AudioSource audioSource;
    private ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
            audioEvent.Play(audioSource);
        
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
