using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class FSM : MonoBehaviour
{
    public enum PlayerStates
    {
        IDLE,
        WALKING,
        JUMPING
    }

    public StateMachine<PlayerStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<PlayerStates>();

        stateMachine.Init();
        //stateMachine.dictionaryStates.Add(PlayerStates.IDLE, new PlayerIdle());
        //stateMachine.dictionaryStates.Add(PlayerStates.WALKING, new PlayerWalking());
        //stateMachine.dictionaryStates.Add(PlayerStates.JUMPING, new PlayerJumping());
        //stateMachine.RegisterStates(PlayerStates.IDLE, new StateIdle());
        //stateMachine.RegisterStates(PlayerStates.WALKING, new StateWalking());
        //stateMachine.RegisterStates(PlayerStates.JUMPING, new StateJumping());

        //stateMachine.SwitchState(PlayerStates.IDLE);
    }
}