using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed =3f;
    [SerializeField]
    private float moveSpeed = 5f;

    private Animator animator;
    private CharacterController characterController;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        GetComponent<PlayerDeath>().OnPlayerDeath += PlayerMovement_OnPlayerDeath;
    }

    

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X");

        animator.SetFloat("Speed", vertical);
        if(Input.GetMouseButton(1) == false)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * rotationSpeed);
        }
        characterController.SimpleMove(transform.forward *vertical * moveSpeed * Time.deltaTime);
    }

    private void PlayerMovement_OnPlayerDeath()
    {
        this.enabled = false;
    }

}
