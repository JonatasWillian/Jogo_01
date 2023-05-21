using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioSource : MonoBehaviour
{
    [Header("Disable Audio")]
    public GameObject musicFight;

    [Header("Music Ambience")]
    public GameObject musicAmbience;

    [Space]
    public string tagPlayer = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagPlayer))
        {
            musicFight.SetActive(true);
            musicAmbience.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagPlayer))
        {
            musicFight.SetActive(false);
            musicAmbience.SetActive(true);
        }
    }
}
