using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDied;
        animator = GetComponent<Animator>();
        var zombieAttack = GetComponent<ZombieAttack>();
        zombieAttack.OnAttack += ZombieAnimator_OnAttack;
    }

    private void ZombieAnimator_OnAttack()
    {
        int valueForAttackType = Random.Range(1, 4);
        animator.SetInteger("AttackID", valueForAttackType);
        animator.SetTrigger("Attack");
    }

    private void ZombieAnimator_OnDied()
    {
        animator.SetTrigger("Die");
    }

    private void ZombieAnimator_OnTookHit()
    {
        animator.SetTrigger("Hit");
    }
}