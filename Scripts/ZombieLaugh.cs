using UnityEngine;

public class ZombieLaugh : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayZombieLaugh()
    {
        audioEvent.Play(audioSource);
    }
}
