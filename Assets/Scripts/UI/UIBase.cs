using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public GameObject text;

    private void Awake()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
