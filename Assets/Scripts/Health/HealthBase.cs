using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Cloth;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public float CurrentLife { get { return _currentLife; } }

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdater> uiFillUpdaters;

    public float damageMultiply = 1;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
        UpDateUI();
    }

    public virtual void Kill()
    {
        if (destroyOnKill)
            Destroy(gameObject, 1f);

        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

    public void Damage(float f)
    {
        _currentLife -= f * damageMultiply;

        if (_currentLife < 10)
        {
            EfectsManager.Instance.ChangeVignette();
        }

        if (_currentLife <= 0)
        {
            Kill();
        }

        UpDateUI();
        OnDamage?.Invoke(this);
    }

    /*public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }*/

    private void UpDateUI()
    {
        if (uiFillUpdaters != null)
        {
            uiFillUpdaters.ForEach(i => i.UpdateValue((float)_currentLife / startLife));
        }
    }

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1f;
    }

    public void ChangeHealth(float life, float duration)
    {
        StartCoroutine(ChangeHealthCoroutine(life, duration));
    }

    IEnumerator ChangeHealthCoroutine(float localStartLife, float duration)
    {
        var defaultStartLife = startLife;
        var lifeIncrese = (localStartLife - startLife);
        startLife = localStartLife;
        _currentLife += lifeIncrese;

        yield return new WaitForSeconds(duration);

        startLife = defaultStartLife;
        _currentLife = Mathf.Min(_currentLife, startLife);
    }
}
