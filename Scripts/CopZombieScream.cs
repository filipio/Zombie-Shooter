using UnityEngine;

public class CopZombieScream : MonoBehaviour
{
    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GetComponentInChildren<CopZombieActivation>().PlayerInRange += CopZombieAddAudio_PlayerInRange;
    }

    private void OnDisable()
    {
        GetComponentInChildren<CopZombieActivation>().PlayerInRange -= CopZombieAddAudio_PlayerInRange;
    }

    private void CopZombieAddAudio_PlayerInRange()
    {
        audioEvent.Play(audioSource);
    }
}
