// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

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
            ""name"": ""RestartGame"",
            ""id"": ""f1370739-d53b-4ca2-b04b-6c75372c8fe7"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""6d76800e-5056-4252-8654-80f0972ba235"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b572fbe-5cb5-48cb-af40-7486e6f64652"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""New control scheme1"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""New control scheme1"",
            ""bindingGroup"": ""New control scheme1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // RestartGame
        m_RestartGame = asset.FindActionMap("RestartGame", throwIfNotFound: true);
        m_RestartGame_Restart = m_RestartGame.FindAction("Restart", throwIfNotFound: true);
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

    // RestartGame
    private readonly InputActionMap m_RestartGame;
    private IRestartGameActions m_RestartGameActionsCallbackInterface;
    private readonly InputAction m_RestartGame_Restart;
    public struct RestartGameActions
    {
        private @Controls m_Wrapper;
        public RestartGameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_RestartGame_Restart;
        public InputActionMap Get() { return m_Wrapper.m_RestartGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RestartGameActions set) { return set.Get(); }
        public void SetCallbacks(IRestartGameActions instance)
        {
            if (m_Wrapper.m_RestartGameActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_RestartGameActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_RestartGameActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_RestartGameActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_RestartGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public RestartGameActions @RestartGame => new RestartGameActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    private int m_Newcontrolscheme1SchemeIndex = -1;
    public InputControlScheme Newcontrolscheme1Scheme
    {
        get
        {
            if (m_Newcontrolscheme1SchemeIndex == -1) m_Newcontrolscheme1SchemeIndex = asset.FindControlSchemeIndex("New control scheme1");
            return asset.controlSchemes[m_Newcontrolscheme1SchemeIndex];
        }
    }
    public interface IRestartGameActions
    {
        void OnRestart(InputAction.CallbackContext context);
    }
}
