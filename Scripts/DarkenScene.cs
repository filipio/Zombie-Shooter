using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DarkenScene : MonoBehaviour
{
    [SerializeField]
    private float brightness = -2;
    [SerializeField]
    private float brightnessChangingSpeed = 0.25f;
    [SerializeField]
    private float timeToWaitBeforeDarkening = 0.5f;

    private PostProcessVolume processVolume;

    private void Awake()
    {
        processVolume = GetComponent<PostProcessVolume>();
    }

    public void MakeSceneDarker()
    {
        ColorGrading colorGrading;
        if(processVolume.profile.TryGetSettings(out colorGrading))
        {
            StartCoroutine(DarkenTheScene(colorGrading));
        }

    }

    private IEnumerator DarkenTheScene(ColorGrading colorGrading)
    {
        yield return new WaitForSeconds(timeToWaitBeforeDarkening);
        while(colorGrading.postExposure.value != brightness)
        {
            colorGrading.postExposure.value = Mathf.Lerp(colorGrading.postExposure.value, brightness, brightnessChangingSpeed);
            yield return null;
        }
    }
}
