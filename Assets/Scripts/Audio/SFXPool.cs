using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Ebac.Core.Singleton;
using static SoundManager;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> _audioSourceList;

    public AudioMixerGroup audioMixerGroup;

    public int poollSize = 10;

    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();

        for (int i = 0; i < poollSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        AudioSource a = go.AddComponent<AudioSource>();
        a.outputAudioMixerGroup = audioMixerGroup;
        _audioSourceList.Add(a);
    }

    public void Play(SFXType sfxType)
    {
        if (sfxType == SFXType.NONE) return;
        var sfx = SoundManager.Instance.GetSFXByType(sfxType);

        _audioSourceList[_index].clip = sfx.audioClip;
        _audioSourceList[_index].Play();

        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;
    }

}

