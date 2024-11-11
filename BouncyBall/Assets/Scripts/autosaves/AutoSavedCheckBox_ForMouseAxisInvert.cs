//using UnityEngine;
//using UnityEngine.UI;
//using Cinemachine;

//public class AutoSavedCheckBox_ForMouseAxisInvert : MonoBehaviour
//{
//    [SerializeField] private CinemachineFreeLook freeLookCamera;
//    [SerializeField] private bool isXAxis;
//    [SerializeField] private Toggle toggle;

//    private void Awake()
//    {
//        bool isInverted = PlayerPrefs.GetInt(isXAxis ? "InvertMouseAxisX" : "InvertMouseAxisY", 0) == 1;
//        toggle.isOn = isInverted;

//        UpdateInvertState(isInverted);

//        toggle.onValueChanged.AddListener(OnToggleValueChanged);
//    }

//    private void OnToggleValueChanged(bool value)
//    {
//        PlayerPrefs.SetInt(isXAxis ? "InvertMouseAxisX" : "InvertMouseAxisY", value ? 1 : 0);
//        PlayerPrefs.Save();
//        UpdateInvertState(value);
//    }

//    private void UpdateInvertState(bool value)
//    {
//        if (isXAxis)
//        {
//            freeLookCamera.m_XAxis.m_InvertInput = value;
//        }
//        else
//        {
//            freeLookCamera.m_YAxis.m_InvertInput = value;
//        }
//    }
//}
