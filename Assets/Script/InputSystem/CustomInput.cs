//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Script/InputSystem/CustomInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CustomInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""558f2b1d-8ae0-427e-8e29-c4be28f874cc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3ff0efd2-5653-4490-89bb-7192ac86fd5f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Value"",
                    ""id"": ""f54f7261-b6a4-4e47-bc49-939a4b94d385"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""PassThrough"",
                    ""id"": ""76e46f75-e9d3-49a4-b001-c2e6a5187bab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slash"",
                    ""type"": ""Value"",
                    ""id"": ""4d19f447-eed4-4f5b-b5d1-aaff5cffb36f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Value"",
                    ""id"": ""8c5616aa-368e-4abc-a5fd-eaed7a3de3a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""bf893a68-e41b-457e-b9cf-cdb126778a38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillPage"",
                    ""type"": ""Value"",
                    ""id"": ""bef910bf-f3e9-4b91-91db-8e786773d5aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""285425a8-5576-44c6-895e-36027c6368de"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d58348c-7b84-4fc1-8e58-574020b09746"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c670161a-fb2f-4e26-8d44-27cd32daf33d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""29fc54c9-5c65-4c47-92a4-efca140595bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3a61f6ec-1205-4c58-bc79-068083433754"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ac937fc-9005-4693-a9bc-03485fe20cf6"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bfa774c-7531-407b-88d9-eab0a03e246d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8b539f0-2569-49ee-9186-d1fa482b9d9c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""420a7bd5-282b-44a0-9afb-18d086a2131d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bc6faf17-8da7-4b93-a881-20095220d694"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cc3bb8c0-9063-48bb-bf07-c20b7290a441"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""51fd52e8-f688-4244-bf14-22712df0ed0c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""da9e378e-2c3d-43f0-89c3-6dad9465fef4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""541062a7-29a9-45d3-a5f6-ad8a395626d9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38695023-54f5-41f4-8a99-81842827ed32"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebbaf2f0-4c33-4d71-9ed8-b665a8fc6dc3"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9f8d1b7-8b08-442a-8cf3-333530852a55"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a60ad52-6dd5-44b9-a288-87e65584ea8f"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillPage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ability"",
            ""id"": ""54752897-59c6-43e5-b3d7-5344e21a9b28"",
            ""actions"": [
                {
                    ""name"": ""Slot_1"",
                    ""type"": ""Value"",
                    ""id"": ""38a2b892-1563-4ca6-a421-9e9e698230b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slot_2"",
                    ""type"": ""Value"",
                    ""id"": ""e2317812-c20d-48dc-ae8b-ff5d7daf94c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slot_3"",
                    ""type"": ""Value"",
                    ""id"": ""e589389c-88fc-4b47-a53b-b6e8e41656c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slot_4"",
                    ""type"": ""Value"",
                    ""id"": ""9f4adab1-60cb-4b6a-8ae1-8e8e3edef182"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slot_5"",
                    ""type"": ""Value"",
                    ""id"": ""e03651d1-0895-4c8b-8db8-7ae10be4e042"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Slot_6"",
                    ""type"": ""Value"",
                    ""id"": ""60698d47-92b8-4737-adec-7abadb87d63b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Value"",
                    ""id"": ""75afbf97-d59a-403e-aba1-c31dc3df07f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b18cefe-9a98-49cf-86eb-16024e4f8d4b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4b484cc-7f4e-4fd9-9920-8b56bf43dae4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bccadd6-67a3-48d6-9de6-d9e33e40c39a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97c08d4a-326c-4e47-97cc-02490c6ff06e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f04c42-96d9-4312-96f6-1b12ff0dddc3"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d16de7c-5c0e-40dd-bd15-c97bfe85c11f"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot_6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""One Modifier"",
                    ""id"": ""d4156382-c620-4d3d-8f30-fe65dc5a2de5"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5fe96773-a182-49f4-8b5c-35f086481527"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""95be66b5-130b-4720-864e-daa80a03b347"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""47d1e25f-772a-4b75-b2a3-4a034d679560"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""746c1d0f-a23c-4eda-9cd8-7d54d210932b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ccb2200-7263-4ab6-9df7-0b3241b23a02"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Slash = m_Player.FindAction("Slash", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_SkillPage = m_Player.FindAction("SkillPage", throwIfNotFound: true);
        // Ability
        m_Ability = asset.FindActionMap("Ability", throwIfNotFound: true);
        m_Ability_Slot_1 = m_Ability.FindAction("Slot_1", throwIfNotFound: true);
        m_Ability_Slot_2 = m_Ability.FindAction("Slot_2", throwIfNotFound: true);
        m_Ability_Slot_3 = m_Ability.FindAction("Slot_3", throwIfNotFound: true);
        m_Ability_Slot_4 = m_Ability.FindAction("Slot_4", throwIfNotFound: true);
        m_Ability_Slot_5 = m_Ability.FindAction("Slot_5", throwIfNotFound: true);
        m_Ability_Slot_6 = m_Ability.FindAction("Slot_6", throwIfNotFound: true);
        m_Ability_Touch = m_Ability.FindAction("Touch", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PauseMenu = m_UI.FindAction("PauseMenu", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Slash;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_SkillPage;
    public struct PlayerActions
    {
        private @CustomInput m_Wrapper;
        public PlayerActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Slash => m_Wrapper.m_Player_Slash;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @SkillPage => m_Wrapper.m_Player_SkillPage;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Slash.started += instance.OnSlash;
            @Slash.performed += instance.OnSlash;
            @Slash.canceled += instance.OnSlash;
            @Use.started += instance.OnUse;
            @Use.performed += instance.OnUse;
            @Use.canceled += instance.OnUse;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @SkillPage.started += instance.OnSkillPage;
            @SkillPage.performed += instance.OnSkillPage;
            @SkillPage.canceled += instance.OnSkillPage;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Slash.started -= instance.OnSlash;
            @Slash.performed -= instance.OnSlash;
            @Slash.canceled -= instance.OnSlash;
            @Use.started -= instance.OnUse;
            @Use.performed -= instance.OnUse;
            @Use.canceled -= instance.OnUse;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @SkillPage.started -= instance.OnSkillPage;
            @SkillPage.performed -= instance.OnSkillPage;
            @SkillPage.canceled -= instance.OnSkillPage;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Ability
    private readonly InputActionMap m_Ability;
    private List<IAbilityActions> m_AbilityActionsCallbackInterfaces = new List<IAbilityActions>();
    private readonly InputAction m_Ability_Slot_1;
    private readonly InputAction m_Ability_Slot_2;
    private readonly InputAction m_Ability_Slot_3;
    private readonly InputAction m_Ability_Slot_4;
    private readonly InputAction m_Ability_Slot_5;
    private readonly InputAction m_Ability_Slot_6;
    private readonly InputAction m_Ability_Touch;
    public struct AbilityActions
    {
        private @CustomInput m_Wrapper;
        public AbilityActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Slot_1 => m_Wrapper.m_Ability_Slot_1;
        public InputAction @Slot_2 => m_Wrapper.m_Ability_Slot_2;
        public InputAction @Slot_3 => m_Wrapper.m_Ability_Slot_3;
        public InputAction @Slot_4 => m_Wrapper.m_Ability_Slot_4;
        public InputAction @Slot_5 => m_Wrapper.m_Ability_Slot_5;
        public InputAction @Slot_6 => m_Wrapper.m_Ability_Slot_6;
        public InputAction @Touch => m_Wrapper.m_Ability_Touch;
        public InputActionMap Get() { return m_Wrapper.m_Ability; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilityActions set) { return set.Get(); }
        public void AddCallbacks(IAbilityActions instance)
        {
            if (instance == null || m_Wrapper.m_AbilityActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AbilityActionsCallbackInterfaces.Add(instance);
            @Slot_1.started += instance.OnSlot_1;
            @Slot_1.performed += instance.OnSlot_1;
            @Slot_1.canceled += instance.OnSlot_1;
            @Slot_2.started += instance.OnSlot_2;
            @Slot_2.performed += instance.OnSlot_2;
            @Slot_2.canceled += instance.OnSlot_2;
            @Slot_3.started += instance.OnSlot_3;
            @Slot_3.performed += instance.OnSlot_3;
            @Slot_3.canceled += instance.OnSlot_3;
            @Slot_4.started += instance.OnSlot_4;
            @Slot_4.performed += instance.OnSlot_4;
            @Slot_4.canceled += instance.OnSlot_4;
            @Slot_5.started += instance.OnSlot_5;
            @Slot_5.performed += instance.OnSlot_5;
            @Slot_5.canceled += instance.OnSlot_5;
            @Slot_6.started += instance.OnSlot_6;
            @Slot_6.performed += instance.OnSlot_6;
            @Slot_6.canceled += instance.OnSlot_6;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(IAbilityActions instance)
        {
            @Slot_1.started -= instance.OnSlot_1;
            @Slot_1.performed -= instance.OnSlot_1;
            @Slot_1.canceled -= instance.OnSlot_1;
            @Slot_2.started -= instance.OnSlot_2;
            @Slot_2.performed -= instance.OnSlot_2;
            @Slot_2.canceled -= instance.OnSlot_2;
            @Slot_3.started -= instance.OnSlot_3;
            @Slot_3.performed -= instance.OnSlot_3;
            @Slot_3.canceled -= instance.OnSlot_3;
            @Slot_4.started -= instance.OnSlot_4;
            @Slot_4.performed -= instance.OnSlot_4;
            @Slot_4.canceled -= instance.OnSlot_4;
            @Slot_5.started -= instance.OnSlot_5;
            @Slot_5.performed -= instance.OnSlot_5;
            @Slot_5.canceled -= instance.OnSlot_5;
            @Slot_6.started -= instance.OnSlot_6;
            @Slot_6.performed -= instance.OnSlot_6;
            @Slot_6.canceled -= instance.OnSlot_6;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(IAbilityActions instance)
        {
            if (m_Wrapper.m_AbilityActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAbilityActions instance)
        {
            foreach (var item in m_Wrapper.m_AbilityActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AbilityActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AbilityActions @Ability => new AbilityActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_PauseMenu;
    public struct UIActions
    {
        private @CustomInput m_Wrapper;
        public UIActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_UI_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @PauseMenu.started += instance.OnPauseMenu;
            @PauseMenu.performed += instance.OnPauseMenu;
            @PauseMenu.canceled += instance.OnPauseMenu;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @PauseMenu.started -= instance.OnPauseMenu;
            @PauseMenu.performed -= instance.OnPauseMenu;
            @PauseMenu.canceled -= instance.OnPauseMenu;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSlash(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSkillPage(InputAction.CallbackContext context);
    }
    public interface IAbilityActions
    {
        void OnSlot_1(InputAction.CallbackContext context);
        void OnSlot_2(InputAction.CallbackContext context);
        void OnSlot_3(InputAction.CallbackContext context);
        void OnSlot_4(InputAction.CallbackContext context);
        void OnSlot_5(InputAction.CallbackContext context);
        void OnSlot_6(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}
