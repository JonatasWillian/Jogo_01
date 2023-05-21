using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Cinemachine;

public class ShakeCamera : Singleton<ShakeCamera>
{
    public CinemachineVirtualCamera virtualCamera;

    public float shakeTime;

    [Header("Shake Values")]
    public float amplitude = 3f;
    public float frequency = 3f;
    public float time = .2f;

    private CinemachineBasicMultiChannelPerlin c;

    [NaughtyAttributes.Button]
    public void Shake()
    {
        Shake(amplitude, frequency, time);
    }

    public void Shake(float amplitude, float frequency, float time)
    {
        c = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        c.m_AmplitudeGain = amplitude;
        c.m_FrequencyGain = frequency;

        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else if(c != null)
        {
            c.m_AmplitudeGain = 0f;
            c.m_FrequencyGain = 0f;
        }
    }
}
