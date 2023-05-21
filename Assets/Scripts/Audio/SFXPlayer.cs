using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SFXPlayer : MonoBehaviour
{
    public SFXType sfxType;
    public AudioSource audioSource;

    private SFXSetup _currentSFXSetup;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        _currentSFXSetup = SoundManager.Instance.GetSFXByType(sfxType);

        audioSource.clip = _currentSFXSetup.audioClip;
        //audioSource.Play();
    }

}
