using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetup;

    [Space]
    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetup.Find(i => i.sfxType == sfxType);
    }

    public enum MusicType
    {
        NONE,
        Type_01,
        Type_02,
        Type_03
    }

    [System.Serializable]
    public class MusicSetup
    {
        public MusicType musicType;
        public AudioClip audioClip;
    }


    public enum SFXType
    {
        NONE,
        Type_01,
        Type_02,
        Type_03
    }

    [System.Serializable]
    public class SFXSetup
    {
        public SFXType sfxType;
        public AudioClip audioClip;
    }
}