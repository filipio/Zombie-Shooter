using UnityEngine;

public class CopZombieDeath : MonoBehaviour
{
    [SerializeField]
    private PooledMonoBehaviour boomParticle;
    [SerializeField]
    private AudioClip boomAudioClip;
    [SerializeField]
    private float volumeScale = 1;
    [SerializeField]
    private int upOffset = 2;

    private void Awake()
    {
        GetComponent<Health>().OnDied += CopZombieDeathParticle_OnDied;
    }

    private void CopZombieDeathParticle_OnDied()
    {
        boomParticle.Get<PooledMonoBehaviour>(transform.position + Vector3.up * upOffset, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(boomAudioClip,volumeScale);
        GetComponent<CopZombieScream>().enabled = false;
    }
}
