using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostSettings : MonoBehaviour
{
    public float currentSaturation;
    public float targetSaturation;
    public float saturationSpeed;
    public PostProcessVolume activeVolume;
    ColorGrading colorGrading;

    public void Start()
    {
        activeVolume.profile.TryGetSettings(out colorGrading);
    }

    public void Update()
    {
        if (currentSaturation != colorGrading.saturation.value) { currentSaturation = colorGrading.saturation.value; }
        if (currentSaturation != targetSaturation)
        {
            // colorGrading.saturation.value = targetSaturation;
            colorGrading.saturation.value = Mathf.Lerp(currentSaturation, targetSaturation, saturationSpeed * Time.deltaTime);
        }
    }

    public void setTargetSaturation(float target)
    {
        targetSaturation = target;
    }

    public void toggleCG()
    {
        print(colorGrading.active);
        if (colorGrading.active == true)
        {
            colorGrading.active = false;
        }
        else if (colorGrading.active == false)
        {
            colorGrading.active = true;
        }
    }
}

