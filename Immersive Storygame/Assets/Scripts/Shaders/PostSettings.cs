using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostSettings : MonoBehaviour
{
    public PostProcessVolume activeVolume;

    public void toggleCG()
    {
        ColorGrading colorGrading;
        activeVolume.profile.TryGetSettings(out colorGrading);
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

