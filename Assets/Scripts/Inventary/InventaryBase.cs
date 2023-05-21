using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventaryBase : MonoBehaviour
{
    [Header("List")]
    public List<GameObject> myObjects;

    [Header("Time")]
    public float delayObjects = .1f;
    public float animationDuration = .3f;

    private bool _isShowinh = false;

    private void Awake()
    {
        Hide();
    }

    private void Hide()
    {
        _isShowinh = false;
        foreach (GameObject g in myObjects)
        {
            g.SetActive(false);
        }
    }

    public void ShowItens()
    {
        if (_isShowinh)
        {
            Hide();
        }
        else
        {
            _isShowinh = true;
            StartCoroutine(Show());
        }
    }

    IEnumerator Show()
    {
        foreach (GameObject g in myObjects)
        {
            yield return new WaitForSeconds(delayObjects);
            g.SetActive(true);
            g.transform.DOScale(0, animationDuration).From();
        }
    }
}
