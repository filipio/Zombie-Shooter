using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    [Tooltip("how long zombie needs to wait between each attack")]
    private float delayBetweenAttacks = 1.5f;
    [SerializeField]
    [Tooltip("how far away the zombie can attack from")]
    private float maximumAttackRange = 1.5f;
    [SerializeField]
    private float delayBetweenAnimationAndDamage = 0.25f;

    public event Action OnAttack = delegate { };

    private float attackTimer;
    private int damage = 1;
    private Health playerHealth;
    private ZombieNavigation zombieNavigation;

    private void Awake()
    {
        zombieNavigation = GetComponent<ZombieNavigation>();
    }

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if(CanAttack())
        {
            attackTimer = 0;
            Attack();
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks &&
            zombieNavigation.IsPlayerAlive
            && IsPlayerInRange();
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    }

    private void Attack()
    {
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
        
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }
}
