using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostSettings : MonoBehaviour
{
    // ShaderManager
    public PostProcessVolume activeVolume;

    // Color Grading (Saturation)
    ColorGrading colorGrading;
    public float currentSaturation;
    [Range (-100.0f, 100.0f)]
    public float targetSaturation;
    public float saturationSpeed = 1;

    // Vignette
    Vignette vignette;
    public float currentVignetteIntensity;
    [Range (0.0f, 1.0f)]
    public float targetVignetteIntensity;
    public float vignetteIntensitySpeed = 1;

    public void Start()
    {
        activeVolume.profile.TryGetSettings(out colorGrading);
        activeVolume.profile.TryGetSettings(out vignette);
    }

    public void Update()
    {
        // Update current float values
        if (currentSaturation != colorGrading.saturation.value) { currentSaturation = colorGrading.saturation.value; }
        if (currentVignetteIntensity != vignette.intensity.value) { currentVignetteIntensity = vignette.intensity.value; }

        // Set new PostProcess colorGrading saturation values
        if (currentSaturation != targetSaturation)
        {
            colorGrading.saturation.value = Mathf.Lerp(currentSaturation, targetSaturation, saturationSpeed * Time.deltaTime);
        }

        // Set new PostProcess vignette intensity values
        if (currentVignetteIntensity != targetVignetteIntensity)
        {
            vignette.intensity.value = Mathf.Lerp(currentVignetteIntensity, targetVignetteIntensity, vignetteIntensitySpeed * Time.deltaTime);
        }
    }

    public void setTargetSaturation(float target)
    {
        targetSaturation = target;
    }

    public void setTargetVignetteIntensity(float target)
    {
        targetVignetteIntensity = target;
    }

    public void toggleCG()
    {
        if (colorGrading.active == true)
        {
            colorGrading.active = false;
        }
        else if (colorGrading.active == false)
        {
            colorGrading.active = true;
        }
    }

    public void toggleVignette()
    {
        if (vignette.active == true)
        {
            vignette.active = false;
        }
        else if (vignette.active == false)
        {
            vignette.active = true;
        }
    }
}

