using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;
    
    [Header("Shake")]
    public float shakeDuration = .1f;
    public int shakeForce = 1;

    [Header("Drop")]
    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        DropGroupCoins();
    }

    [NaughtyAttributes.Button]
    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, .8f).SetEase(Ease.OutBack).From();
    }

    [NaughtyAttributes.Button]
    private void DropGroupCoins()
    {
        StartCoroutine(DropGroupCoinsCoroutine());
    }

    IEnumerator DropGroupCoinsCoroutine()
    {
        for (int i = 0; i < dropCoinsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }
}
