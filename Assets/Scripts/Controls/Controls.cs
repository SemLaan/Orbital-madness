// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""31978ebf-5172-4a9c-9632-096fe851477e"",
            ""actions"": [
                {
                    ""name"": ""leftMouse"",
                    ""type"": ""Value"",
                    ""id"": ""75f3c208-3f61-48ae-94fb-9fcc59c61a86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rightMouse"",
                    ""type"": ""Value"",
                    ""id"": ""b2f7c0e0-7404-45e8-978b-e350812deae1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""mousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""014349fe-fc93-4290-9150-d93befa31d87"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""scrollWheel"",
                    ""type"": ""Value"",
                    ""id"": ""4d5cd6b1-9495-4f0e-9a43-71b476f99fa4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a53c6547-c00d-4bda-bbb6-7395e15d41b8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3ea3347-c713-4526-9a70-4a37d52f1d59"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rightMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a22414e2-956c-47ee-ae5c-362910552a92"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2021874e-9b5a-4f71-b942-8c287d864dfc"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""scrollWheel"",
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
        m_Gameplay_leftMouse = m_Gameplay.FindAction("leftMouse", throwIfNotFound: true);
        m_Gameplay_rightMouse = m_Gameplay.FindAction("rightMouse", throwIfNotFound: true);
        m_Gameplay_mousePosition = m_Gameplay.FindAction("mousePosition", throwIfNotFound: true);
        m_Gameplay_scrollWheel = m_Gameplay.FindAction("scrollWheel", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_leftMouse;
    private readonly InputAction m_Gameplay_rightMouse;
    private readonly InputAction m_Gameplay_mousePosition;
    private readonly InputAction m_Gameplay_scrollWheel;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @leftMouse => m_Wrapper.m_Gameplay_leftMouse;
        public InputAction @rightMouse => m_Wrapper.m_Gameplay_rightMouse;
        public InputAction @mousePosition => m_Wrapper.m_Gameplay_mousePosition;
        public InputAction @scrollWheel => m_Wrapper.m_Gameplay_scrollWheel;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @leftMouse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMouse;
                @leftMouse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMouse;
                @leftMouse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftMouse;
                @rightMouse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMouse;
                @rightMouse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMouse;
                @rightMouse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightMouse;
                @mousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @mousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @mousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @scrollWheel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScrollWheel;
                @scrollWheel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScrollWheel;
                @scrollWheel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScrollWheel;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @leftMouse.started += instance.OnLeftMouse;
                @leftMouse.performed += instance.OnLeftMouse;
                @leftMouse.canceled += instance.OnLeftMouse;
                @rightMouse.started += instance.OnRightMouse;
                @rightMouse.performed += instance.OnRightMouse;
                @rightMouse.canceled += instance.OnRightMouse;
                @mousePosition.started += instance.OnMousePosition;
                @mousePosition.performed += instance.OnMousePosition;
                @mousePosition.canceled += instance.OnMousePosition;
                @scrollWheel.started += instance.OnScrollWheel;
                @scrollWheel.performed += instance.OnScrollWheel;
                @scrollWheel.canceled += instance.OnScrollWheel;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnLeftMouse(InputAction.CallbackContext context);
        void OnRightMouse(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
    }
}
