using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostSettings : MonoBehaviour
{
    public PostProcessVolume activeVolume;

    public void toggleCG(bool value)
    {
        ColorGrading colorGrading;
        activeVolume.profile.TryGetSettings(out colorGrading);

        if (value)
        {
            colorGrading.active = true;
        }
        else 
        {
            colorGrading.active = false;
        }
    }

    // public PostProcessProfile effects;
    // public float vignette = 0f;
    // public float saturation = 0f;

}
