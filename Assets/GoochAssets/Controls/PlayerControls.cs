// GENERATED AUTOMATICALLY FROM 'Assets/GoochAssets/Controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerOne"",
            ""id"": ""eb1e409e-930f-48bc-a662-933724a4d03b"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""00085b0f-5db7-438e-865b-cc4676efebe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""9c81d41c-8b26-43b3-9433-83dd46f8d8d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FP_Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3bf1000e-09cb-45c8-a9dd-0f43fb272c0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Split_Merge"",
                    ""type"": ""Button"",
                    ""id"": ""a85bb78e-77ae-4f22-949a-7a882a44e908"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""46e9f46e-3c22-4cad-8d3e-621b5476bf3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Grapple"",
                    ""type"": ""Button"",
                    ""id"": ""081f5f8c-a0b4-44c2-b870-76053d6e650f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reload1"",
                    ""type"": ""Button"",
                    ""id"": ""c44cfb7e-a7cb-4308-81ba-bacf72fbea2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reload2"",
                    ""type"": ""Button"",
                    ""id"": ""1be08d83-9eac-463c-a197-5cef3d49a041"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ToggleCursor"",
                    ""type"": ""Button"",
                    ""id"": ""0e5d1a64-c818-402e-bf24-a108701f58dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3914fd56-a1cb-47c3-a76e-d049aa37651b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f89aefe-8fae-4fff-90eb-f009d2c279c3"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""acc4df87-9ea9-4070-9728-3c219c24cab9"",
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
                    ""id"": ""7a5cf63d-644f-44e7-bbc1-6c3a897b9fc9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c53e8b23-1b9d-4ffb-98ec-c015d5752356"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0981bbac-1f85-4105-9b36-455c94990f63"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9f459be-6b95-4a47-9898-1349c4027d1b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XB Controller"",
                    ""id"": ""d81e569e-838d-4079-9c1b-0275b75bea97"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45e31004-fb8e-446a-95ad-8b6466e116cb"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ce1c278e-cd9e-4c4c-8aab-fe7faae6b596"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""229677cb-056f-4bf6-9b11-630adf9fb16e"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5cbbc947-7f39-4dcf-b064-d4bfea9b9c94"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XB Controller"",
                    ""id"": ""960b2352-5d8d-4164-8636-01da7f9f0fd5"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4b03b2eb-b9e2-4444-9b94-abc1c0877ddc"",
                    ""path"": ""<XInputController>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""69ffc40c-6a8b-4621-855e-e6591348e184"",
                    ""path"": ""<XInputController>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d54e902b-a3b7-42a2-bb07-ebb2ce812dc9"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2c5744c6-f6c7-4cc4-976f-8cc255f8276a"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c3b074ea-2d35-4e73-9057-c6343db134fc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""FP_Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa619b80-663f-457d-9253-907d4b24c779"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Split_Merge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""636ed6cb-1ef9-4f07-8be4-b3398a0b13cb"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Split_Merge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dd68342-9e69-4e04-bee6-a23be1865c81"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dab6b4bc-06e0-4248-837f-63882b9c42b0"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""521e5640-1a07-4f34-bbc8-fb1945ea4325"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XB_Gamepad"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08821ab2-8bab-4ab0-8b70-b4c7a21214df"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Grapple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""179d324f-69cf-45ca-818f-097480e5feab"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Reload1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0ab5e4c-fb8b-4605-a146-6c6d6c9f7d0f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""Reload2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c9f3596-9041-4222-81dd-f0d25719d464"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB&M"",
                    ""action"": ""ToggleCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB&M"",
            ""bindingGroup"": ""KB&M"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XB_Gamepad"",
            ""bindingGroup"": ""XB_Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS_Gamepad"",
            ""bindingGroup"": ""PS_Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerOne
        m_PlayerOne = asset.FindActionMap("PlayerOne", throwIfNotFound: true);
        m_PlayerOne_Jump = m_PlayerOne.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOne_Movement = m_PlayerOne.FindAction("Movement", throwIfNotFound: true);
        m_PlayerOne_FP_Camera = m_PlayerOne.FindAction("FP_Camera", throwIfNotFound: true);
        m_PlayerOne_Split_Merge = m_PlayerOne.FindAction("Split_Merge", throwIfNotFound: true);
        m_PlayerOne_Fire = m_PlayerOne.FindAction("Fire", throwIfNotFound: true);
        m_PlayerOne_Grapple = m_PlayerOne.FindAction("Grapple", throwIfNotFound: true);
        m_PlayerOne_Reload1 = m_PlayerOne.FindAction("Reload1", throwIfNotFound: true);
        m_PlayerOne_Reload2 = m_PlayerOne.FindAction("Reload2", throwIfNotFound: true);
        m_PlayerOne_ToggleCursor = m_PlayerOne.FindAction("ToggleCursor", throwIfNotFound: true);
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

    // PlayerOne
    private readonly InputActionMap m_PlayerOne;
    private IPlayerOneActions m_PlayerOneActionsCallbackInterface;
    private readonly InputAction m_PlayerOne_Jump;
    private readonly InputAction m_PlayerOne_Movement;
    private readonly InputAction m_PlayerOne_FP_Camera;
    private readonly InputAction m_PlayerOne_Split_Merge;
    private readonly InputAction m_PlayerOne_Fire;
    private readonly InputAction m_PlayerOne_Grapple;
    private readonly InputAction m_PlayerOne_Reload1;
    private readonly InputAction m_PlayerOne_Reload2;
    private readonly InputAction m_PlayerOne_ToggleCursor;
    public struct PlayerOneActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerOneActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerOne_Jump;
        public InputAction @Movement => m_Wrapper.m_PlayerOne_Movement;
        public InputAction @FP_Camera => m_Wrapper.m_PlayerOne_FP_Camera;
        public InputAction @Split_Merge => m_Wrapper.m_PlayerOne_Split_Merge;
        public InputAction @Fire => m_Wrapper.m_PlayerOne_Fire;
        public InputAction @Grapple => m_Wrapper.m_PlayerOne_Grapple;
        public InputAction @Reload1 => m_Wrapper.m_PlayerOne_Reload1;
        public InputAction @Reload2 => m_Wrapper.m_PlayerOne_Reload2;
        public InputAction @ToggleCursor => m_Wrapper.m_PlayerOne_ToggleCursor;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOne; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOneActions instance)
        {
            if (m_Wrapper.m_PlayerOneActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Movement.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMovement;
                @FP_Camera.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFP_Camera;
                @FP_Camera.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFP_Camera;
                @FP_Camera.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFP_Camera;
                @Split_Merge.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSplit_Merge;
                @Split_Merge.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSplit_Merge;
                @Split_Merge.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSplit_Merge;
                @Fire.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnFire;
                @Grapple.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnGrapple;
                @Grapple.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnGrapple;
                @Grapple.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnGrapple;
                @Reload1.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload1;
                @Reload1.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload1;
                @Reload1.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload1;
                @Reload2.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload2;
                @Reload2.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload2;
                @Reload2.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnReload2;
                @ToggleCursor.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnToggleCursor;
                @ToggleCursor.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnToggleCursor;
                @ToggleCursor.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnToggleCursor;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @FP_Camera.started += instance.OnFP_Camera;
                @FP_Camera.performed += instance.OnFP_Camera;
                @FP_Camera.canceled += instance.OnFP_Camera;
                @Split_Merge.started += instance.OnSplit_Merge;
                @Split_Merge.performed += instance.OnSplit_Merge;
                @Split_Merge.canceled += instance.OnSplit_Merge;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Grapple.started += instance.OnGrapple;
                @Grapple.performed += instance.OnGrapple;
                @Grapple.canceled += instance.OnGrapple;
                @Reload1.started += instance.OnReload1;
                @Reload1.performed += instance.OnReload1;
                @Reload1.canceled += instance.OnReload1;
                @Reload2.started += instance.OnReload2;
                @Reload2.performed += instance.OnReload2;
                @Reload2.canceled += instance.OnReload2;
                @ToggleCursor.started += instance.OnToggleCursor;
                @ToggleCursor.performed += instance.OnToggleCursor;
                @ToggleCursor.canceled += instance.OnToggleCursor;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KB&M");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    private int m_XB_GamepadSchemeIndex = -1;
    public InputControlScheme XB_GamepadScheme
    {
        get
        {
            if (m_XB_GamepadSchemeIndex == -1) m_XB_GamepadSchemeIndex = asset.FindControlSchemeIndex("XB_Gamepad");
            return asset.controlSchemes[m_XB_GamepadSchemeIndex];
        }
    }
    private int m_PS_GamepadSchemeIndex = -1;
    public InputControlScheme PS_GamepadScheme
    {
        get
        {
            if (m_PS_GamepadSchemeIndex == -1) m_PS_GamepadSchemeIndex = asset.FindControlSchemeIndex("PS_Gamepad");
            return asset.controlSchemes[m_PS_GamepadSchemeIndex];
        }
    }
    public interface IPlayerOneActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnFP_Camera(InputAction.CallbackContext context);
        void OnSplit_Merge(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnGrapple(InputAction.CallbackContext context);
        void OnReload1(InputAction.CallbackContext context);
        void OnReload2(InputAction.CallbackContext context);
        void OnToggleCursor(InputAction.CallbackContext context);
    }
}
