using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityBase : MonoBehaviour
{
    protected Player player;

    protected Inputs inputs;

    private void OnValidate()
    {
        if (player == null) player = GetComponent<Player>();
    }

    private void Start()
    {
        inputs = new Inputs();
        inputs.Enable();

        Init();
        OnValidate();
        RegistersListeners();
    }

    private void OnEnable()
    {
        if(inputs != null)
            inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    private void OnDestroy()
    {
        RemoveListeners();
    }

    protected virtual void Init() { }

    protected virtual void RegistersListeners() { }

    protected virtual void RemoveListeners() { }
}
