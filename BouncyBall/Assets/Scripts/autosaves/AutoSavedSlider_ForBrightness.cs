using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class AutoSavedSlider_ForBrightness : AutoSavedSlider
{
    [SerializeField] private Volume globalVolume;
    [SerializeField] private float minExposure = -2f;
    [SerializeField] private float maxExposure = 2f;


    private ColorAdjustments colorAdjustments;

    protected override void Awake()
    {
        base.Awake();

        if (globalVolume != null && globalVolume.profile.TryGet(out colorAdjustments))
        {
            // ColorAdjustments fue encontrado en el perfil del Volume
        }
        else
        {
            Debug.LogError("Color Adjustments no encontrado en el perfil del Volume. Asegúrate de que el componente está agregado.");
        }
    }

    protected override void InternalValueChanged(float value)
    {
        colorAdjustments.postExposure.value = Mathf.Lerp(minExposure, maxExposure, value);
    }
}
