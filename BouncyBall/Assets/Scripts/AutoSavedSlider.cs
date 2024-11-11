using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedSlider : MonoBehaviour
{
    [SerializeField] private string prefKey; 
    [SerializeField] private float defaultValue = 0.5f;   

    protected Slider slider;


    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();

        float savedValue = PlayerPrefs.GetFloat(prefKey, defaultValue);

        slider.value = savedValue;

        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    protected virtual void Start()
    {
        InternalValueChanged(slider.value);
    }

    private void OnSliderValueChanged(float newValue)
    {
        PlayerPrefs.SetFloat(prefKey, newValue);

        PlayerPrefs.Save();

        InternalValueChanged(newValue);
    }

    protected virtual void InternalValueChanged(float value)
    {
        
    }
}