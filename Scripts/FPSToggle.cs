using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] firstPersonObjects;
    [SerializeField]
    private GameObject[] thirdPersonObjects;
    [SerializeField]
    private KeyCode toggleKey = KeyCode.V;

    private bool isFpsMode;
    private Weapons weapons;

    private void Awake()
    {
        weapons = FindObjectOfType<Weapons>().GetComponent<Weapons>();
    }
    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }
    void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;
        weapons.IsFpsMode = isFpsMode;

        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(isFpsMode);
        }

        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!isFpsMode);
        }
    }
}
