//using UnityEngine;
//using UnityEngine.UI;
//using Cinemachine; 

//public class AutoSavedSlider_ForMouseAxisSensitivityX : MonoBehaviour
//{
//    [SerializeField] private CinemachineFreeLook freeLookCamera;
//    [SerializeField] private float minMultiplier = 0.1f;
//    [SerializeField] private float maxMultiplier = 5f;
//    [SerializeField] private Slider slider; 

//    private void Awake()
//    {
//        float savedValue = PlayerPrefs.GetFloat("MouseSensitivityX", 1f);
//        slider.value = savedValue;

//        slider.onValueChanged.AddListener(OnSliderValueChanged);
//    }

//    private void OnSliderValueChanged(float value)
//    {
//        PlayerPrefs.SetFloat("MouseSensitivityX", value);
//        PlayerPrefs.Save();

//        InternalValueChanged(value);
//    }

//    private void InternalValueChanged(float value)
//    {
//        float interpolatedValue = Mathf.Lerp(minMultiplier, maxMultiplier, value);
//        freeLookCamera.m_XAxis.m_MaxSpeed = interpolatedValue;
//    }
//}
