// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""8b90ad4a-4b83-42f3-9ded-2c6d07bc90aa"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d9c3d662-1ce5-4fe6-b1b9-fc54fab70b50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityShoot_1"",
                    ""type"": ""Button"",
                    ""id"": ""78e2fad8-85e9-4706-9bfb-c677cba234cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityShoot_2"",
                    ""type"": ""Button"",
                    ""id"": ""501ecc9e-da20-47b7-be1f-198cea34ebda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityShoot_3"",
                    ""type"": ""Button"",
                    ""id"": ""a36ac4ec-8a77-4868-b7ba-d526c32206a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83535a4b-d279-4f51-bad0-6cbbdedddfcb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""344753cf-8ee1-441c-ada5-48d723f241f2"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityShoot_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84be109f-3e03-4b24-bb77-44fc80b7ce47"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityShoot_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9d11459-7a36-4227-bbf5-d1d54981b924"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityShoot_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_AbilityShoot_1 = m_Gameplay.FindAction("AbilityShoot_1", throwIfNotFound: true);
        m_Gameplay_AbilityShoot_2 = m_Gameplay.FindAction("AbilityShoot_2", throwIfNotFound: true);
        m_Gameplay_AbilityShoot_3 = m_Gameplay.FindAction("AbilityShoot_3", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_AbilityShoot_1;
    private readonly InputAction m_Gameplay_AbilityShoot_2;
    private readonly InputAction m_Gameplay_AbilityShoot_3;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @AbilityShoot_1 => m_Wrapper.m_Gameplay_AbilityShoot_1;
        public InputAction @AbilityShoot_2 => m_Wrapper.m_Gameplay_AbilityShoot_2;
        public InputAction @AbilityShoot_3 => m_Wrapper.m_Gameplay_AbilityShoot_3;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @AbilityShoot_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_1;
                @AbilityShoot_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_1;
                @AbilityShoot_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_1;
                @AbilityShoot_2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_2;
                @AbilityShoot_2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_2;
                @AbilityShoot_2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_2;
                @AbilityShoot_3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_3;
                @AbilityShoot_3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_3;
                @AbilityShoot_3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAbilityShoot_3;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @AbilityShoot_1.started += instance.OnAbilityShoot_1;
                @AbilityShoot_1.performed += instance.OnAbilityShoot_1;
                @AbilityShoot_1.canceled += instance.OnAbilityShoot_1;
                @AbilityShoot_2.started += instance.OnAbilityShoot_2;
                @AbilityShoot_2.performed += instance.OnAbilityShoot_2;
                @AbilityShoot_2.canceled += instance.OnAbilityShoot_2;
                @AbilityShoot_3.started += instance.OnAbilityShoot_3;
                @AbilityShoot_3.performed += instance.OnAbilityShoot_3;
                @AbilityShoot_3.canceled += instance.OnAbilityShoot_3;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnAbilityShoot_1(InputAction.CallbackContext context);
        void OnAbilityShoot_2(InputAction.CallbackContext context);
        void OnAbilityShoot_3(InputAction.CallbackContext context);
    }
}
