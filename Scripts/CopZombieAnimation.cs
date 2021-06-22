using UnityEngine;

public class CopZombieAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponentInChildren<CopZombieActivation>().PlayerInRange += CopZombieAnimation_PlayerInRange;
        GetComponent<Health>().OnDied += CopZombieAnimation_OnDied;
    }

    private void CopZombieAnimation_OnDied()
    {
        animator.SetTrigger("Die");
    }

    private void CopZombieAnimation_PlayerInRange()
    {
        animator.SetTrigger("Scream");
    }

}
