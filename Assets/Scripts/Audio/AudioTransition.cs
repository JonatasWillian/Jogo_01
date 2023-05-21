using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    public AudioMixerSnapshot snapShot;
    public float timeTransition = .1f;

    public void MakeTransition()
    {
        snapShot.TransitionTo(timeTransition);
    }
}
