using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

    private bool CheckPointActived = false;
    private string checkPointKey = "CheckPointKey";

    public GameObject text;
    private Coroutine checkPointCoroutine = null;

    private bool once = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!CheckPointActived && other.transform.tag == "Player" && once)
        {
            once = false;
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();

        if (checkPointCoroutine != null)
            StopCoroutine(checkPointCoroutine);

        checkPointCoroutine = StartCoroutine(CheckPointCoroutine());
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.gray);
    }

    private void SaveCheckPoint()
    {
        /*if(PlayerPrefs.GetInt(checkPointKey, 0) > key)
            PlayerPrefs.SetInt(checkPointKey, key);*/

        CheckPointManager.Instance.SaveCheckPoint(key);

        CheckPointActived = true;
    }

    IEnumerator CheckPointCoroutine()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(.5f);
        text.gameObject.SetActive(false);

        checkPointCoroutine = null;
    }
}
