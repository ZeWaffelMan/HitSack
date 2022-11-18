using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Colorizer : MonoBehaviour
{
    private ColorGrading colorGrading = default;
    private float hueShiftMin = -100f;
    private float hueShiftMax = 100f;

    private void Awake()
    {
        var postProcessVolume = FindObjectOfType<PostProcessVolume>();
        colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
            ChangeColor();
    }

    public void ChangeColor()
    {
        colorGrading.hueShift.value = Random.Range(hueShiftMin, hueShiftMax);
    }
}
