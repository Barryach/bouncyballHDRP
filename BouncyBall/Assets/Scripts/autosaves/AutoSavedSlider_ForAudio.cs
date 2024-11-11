using UnityEngine;
using UnityEngine.Audio;

public class AutoSavedSlider_ForAudio : AutoSavedSlider
{
    public AudioMixer mixer;
    [SerializeField] string parameterName;

    protected override void InternalValueChanged(float value)
    {
        mixer.SetFloat(parameterName, LinearToDecibel(value));
    }

    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }

}
