using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{   [Header("Third Person")]
    [SerializeField]
    CinemachineVirtualCamera followCamera;
    [SerializeField]
    CinemachineFreeLook lookAroundCamera;
    [SerializeField]
    private float thirdPersonMouseLookSensitivity=1f;

     [Header("First Person")]
    [SerializeField]
    private float fpsMouseLookSensitivity = 2f;
    [SerializeField]
    CinemachineVirtualCamera fpsCamera;

    private CinemachineComposer aim;

    private void Awake()
    {
        aim = followCamera.GetCinemachineComponent<CinemachineComposer>();
        var volume = GetComponent<PostProcessVolume>();
        /*AmbientOcclusion ambient;
        if(volume.profile.TryGetSettings(out ambient))
        {
            ambient.enabled.value = true;
            ambient.intensity.value = 0.2f;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetMouseButtonDown(1))
        {
            lookAroundCamera.Priority = 100;
            lookAroundCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            lookAroundCamera.Priority = 0;
            lookAroundCamera.m_RecenterToTargetHeading.m_enabled = true;
        }
        if(Input.GetMouseButton(1) == false)
        {
            var vertical = Input.GetAxis("Mouse Y") * thirdPersonMouseLookSensitivity;
            aim.m_TrackedObjectOffset.y += vertical;
            aim.m_TrackedObjectOffset.y = Mathf.Clamp(aim.m_TrackedObjectOffset.y, -10f, 10f);
        }

        var fpsVertical = Input.GetAxis("Mouse Y") * fpsMouseLookSensitivity;
        fpsCamera.transform.Rotate(Vector3.right, -fpsVertical);
    }

    public void OnPlayerDeath()
    {
        GetComponent<DarkenScene>().MakeSceneDarker();
        followCamera.Priority = 500;
        followCamera.GetComponent<Animator>().enabled = true;
        this.enabled = false;
    }
}
