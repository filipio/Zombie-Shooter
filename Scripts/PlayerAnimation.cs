using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float drawWeaponSpeed;
    [SerializeField]
    private float delayBeforeWeaponDown = 3f;

    private Coroutine currentCoroutine;
    private float currentWeightOfAnimator;

    public bool IsInFireMode { get { return currentWeightOfAnimator == 1; } }

    private void Awake()
    {
        GetComponent<Health>().OnDied += PlayerAnimation_OnDied;
    }


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            

           currentCoroutine =  StartCoroutine(FadeToShootingLayer());
        }
        else if(Input.GetButtonUp("Fire1"))
        {
               currentCoroutine =  StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeFromShootingLayer()
    {
        yield return currentCoroutine;
        yield return new WaitForSeconds(delayBeforeWeaponDown);

        currentWeightOfAnimator = animator.GetLayerWeight(1);
        float elapsed = 0f;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeightOfAnimator -= Time.deltaTime / drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeightOfAnimator);
            yield return null;
        }
        currentWeightOfAnimator = 0;
        animator.SetLayerWeight(1, currentWeightOfAnimator);

    }

    private IEnumerator FadeToShootingLayer()
    {
        currentWeightOfAnimator = animator.GetLayerWeight(1);
        float elapsed = 0f;

        while(elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeightOfAnimator += Time.deltaTime/drawWeaponSpeed;
            animator.SetLayerWeight(1, currentWeightOfAnimator);
            yield return null;
        }
        currentWeightOfAnimator = 1;
        animator.SetLayerWeight(1, currentWeightOfAnimator);
    }

    private void PlayerAnimation_OnDied()
    {
        animator.transform.parent = null;
        animator.applyRootMotion = true;
        animator.SetTrigger("Die");
        gameObject.SetActive(false);
    }
}
