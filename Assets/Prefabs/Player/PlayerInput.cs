//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Prefabs/Player/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""XRRightController"",
            ""id"": ""5bc201b4-580e-4035-8cf0-3e7cfc830012"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""34548d79-4d48-47e6-b9d1-a5c2f001e595"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""b878e206-8dbb-4894-b04c-065d009ede36"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TriggerAxis"",
                    ""type"": ""Value"",
                    ""id"": ""7073aae9-de9a-4e12-ab93-6d27d6894f5b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GripAxis"",
                    ""type"": ""Value"",
                    ""id"": ""fdfbbd6a-7a3c-4e3e-a597-470a5aba8efd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GripButton"",
                    ""type"": ""Button"",
                    ""id"": ""e7d314e1-ae32-4483-836e-9899e1c0f4b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerPress"",
                    ""type"": ""Button"",
                    ""id"": ""668c2a4f-7700-4c90-9b37-726d44b76303"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9d053554-a0c2-45ea-9519-8da962fedd38"",
                    ""path"": ""<XRController>{RightHand}/pointerPosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20e950f2-6356-46e8-bbac-73ef4ab7cc99"",
                    ""path"": ""<XRController>{RightHand}/pointerRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1e1207d-5095-438a-b851-8db136ecda55"",
                    ""path"": ""<XRController>{RightHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36afef02-c382-40c9-95da-3efa4dced914"",
                    ""path"": ""<XRController>{RightHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7668446c-db9a-4cc6-ac55-84123d394f1a"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b19b4b20-dc8d-4bd1-97cf-56386680fc74"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""XRLeftController"",
            ""id"": ""f9f93a63-2e70-4a90-80af-a4c4bd340199"",
            ""actions"": [
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""d62bc034-2099-4ab2-a862-b72b0017e695"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""4f3d1586-e529-4f1c-b3fa-4b95e3bbe332"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""ea166de0-0d42-4340-b461-bcbbff6f35ca"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TriggerAxis"",
                    ""type"": ""Value"",
                    ""id"": ""07696cf9-1194-448b-9bb7-4b31b892ce0d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GripAxis"",
                    ""type"": ""Value"",
                    ""id"": ""88d4ac43-88fc-4c59-9cf3-f9b5b331b870"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""GripButton"",
                    ""type"": ""Button"",
                    ""id"": ""cd842a92-9623-409f-9b03-c2576dc38a13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerPress"",
                    ""type"": ""Button"",
                    ""id"": ""97d3859b-4ca8-4171-845a-0ecaf11f2711"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""33863f19-3347-4749-a6e5-450518aab7ab"",
                    ""path"": ""<XRController>{LeftHand}/joystick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22ed47eb-8411-4877-92b2-168ea6f12b64"",
                    ""path"": ""<XRController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9353a316-19bd-4d88-adec-2dd091e625e5"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17a06f64-cd8c-4c41-9346-5b482685b4f5"",
                    ""path"": ""<XRController>{LeftHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ad08d3a-5d74-410b-8afb-33d4230890ad"",
                    ""path"": ""<XRController>{LeftHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e46bdca5-0df0-44ba-ba29-99bb05601463"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a602068-4afe-4fc6-9a0b-1a9ee5096570"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // XRRightController
        m_XRRightController = asset.FindActionMap("XRRightController", throwIfNotFound: true);
        m_XRRightController_Position = m_XRRightController.FindAction("Position", throwIfNotFound: true);
        m_XRRightController_Rotation = m_XRRightController.FindAction("Rotation", throwIfNotFound: true);
        m_XRRightController_TriggerAxis = m_XRRightController.FindAction("TriggerAxis", throwIfNotFound: true);
        m_XRRightController_GripAxis = m_XRRightController.FindAction("GripAxis", throwIfNotFound: true);
        m_XRRightController_GripButton = m_XRRightController.FindAction("GripButton", throwIfNotFound: true);
        m_XRRightController_TriggerPress = m_XRRightController.FindAction("TriggerPress", throwIfNotFound: true);
        // XRLeftController
        m_XRLeftController = asset.FindActionMap("XRLeftController", throwIfNotFound: true);
        m_XRLeftController_LeftStick = m_XRLeftController.FindAction("LeftStick", throwIfNotFound: true);
        m_XRLeftController_Position = m_XRLeftController.FindAction("Position", throwIfNotFound: true);
        m_XRLeftController_Rotation = m_XRLeftController.FindAction("Rotation", throwIfNotFound: true);
        m_XRLeftController_TriggerAxis = m_XRLeftController.FindAction("TriggerAxis", throwIfNotFound: true);
        m_XRLeftController_GripAxis = m_XRLeftController.FindAction("GripAxis", throwIfNotFound: true);
        m_XRLeftController_GripButton = m_XRLeftController.FindAction("GripButton", throwIfNotFound: true);
        m_XRLeftController_TriggerPress = m_XRLeftController.FindAction("TriggerPress", throwIfNotFound: true);
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

    // XRRightController
    private readonly InputActionMap m_XRRightController;
    private IXRRightControllerActions m_XRRightControllerActionsCallbackInterface;
    private readonly InputAction m_XRRightController_Position;
    private readonly InputAction m_XRRightController_Rotation;
    private readonly InputAction m_XRRightController_TriggerAxis;
    private readonly InputAction m_XRRightController_GripAxis;
    private readonly InputAction m_XRRightController_GripButton;
    private readonly InputAction m_XRRightController_TriggerPress;
    public struct XRRightControllerActions
    {
        private @PlayerInput m_Wrapper;
        public XRRightControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_XRRightController_Position;
        public InputAction @Rotation => m_Wrapper.m_XRRightController_Rotation;
        public InputAction @TriggerAxis => m_Wrapper.m_XRRightController_TriggerAxis;
        public InputAction @GripAxis => m_Wrapper.m_XRRightController_GripAxis;
        public InputAction @GripButton => m_Wrapper.m_XRRightController_GripButton;
        public InputAction @TriggerPress => m_Wrapper.m_XRRightController_TriggerPress;
        public InputActionMap Get() { return m_Wrapper.m_XRRightController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRRightControllerActions set) { return set.Get(); }
        public void SetCallbacks(IXRRightControllerActions instance)
        {
            if (m_Wrapper.m_XRRightControllerActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnRotation;
                @TriggerAxis.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerAxis;
                @TriggerAxis.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerAxis;
                @TriggerAxis.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerAxis;
                @GripAxis.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripAxis;
                @GripAxis.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripAxis;
                @GripAxis.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripAxis;
                @GripButton.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripButton;
                @GripButton.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripButton;
                @GripButton.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnGripButton;
                @TriggerPress.started -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerPress;
                @TriggerPress.performed -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerPress;
                @TriggerPress.canceled -= m_Wrapper.m_XRRightControllerActionsCallbackInterface.OnTriggerPress;
            }
            m_Wrapper.m_XRRightControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @TriggerAxis.started += instance.OnTriggerAxis;
                @TriggerAxis.performed += instance.OnTriggerAxis;
                @TriggerAxis.canceled += instance.OnTriggerAxis;
                @GripAxis.started += instance.OnGripAxis;
                @GripAxis.performed += instance.OnGripAxis;
                @GripAxis.canceled += instance.OnGripAxis;
                @GripButton.started += instance.OnGripButton;
                @GripButton.performed += instance.OnGripButton;
                @GripButton.canceled += instance.OnGripButton;
                @TriggerPress.started += instance.OnTriggerPress;
                @TriggerPress.performed += instance.OnTriggerPress;
                @TriggerPress.canceled += instance.OnTriggerPress;
            }
        }
    }
    public XRRightControllerActions @XRRightController => new XRRightControllerActions(this);

    // XRLeftController
    private readonly InputActionMap m_XRLeftController;
    private IXRLeftControllerActions m_XRLeftControllerActionsCallbackInterface;
    private readonly InputAction m_XRLeftController_LeftStick;
    private readonly InputAction m_XRLeftController_Position;
    private readonly InputAction m_XRLeftController_Rotation;
    private readonly InputAction m_XRLeftController_TriggerAxis;
    private readonly InputAction m_XRLeftController_GripAxis;
    private readonly InputAction m_XRLeftController_GripButton;
    private readonly InputAction m_XRLeftController_TriggerPress;
    public struct XRLeftControllerActions
    {
        private @PlayerInput m_Wrapper;
        public XRLeftControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStick => m_Wrapper.m_XRLeftController_LeftStick;
        public InputAction @Position => m_Wrapper.m_XRLeftController_Position;
        public InputAction @Rotation => m_Wrapper.m_XRLeftController_Rotation;
        public InputAction @TriggerAxis => m_Wrapper.m_XRLeftController_TriggerAxis;
        public InputAction @GripAxis => m_Wrapper.m_XRLeftController_GripAxis;
        public InputAction @GripButton => m_Wrapper.m_XRLeftController_GripButton;
        public InputAction @TriggerPress => m_Wrapper.m_XRLeftController_TriggerPress;
        public InputActionMap Get() { return m_Wrapper.m_XRLeftController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(XRLeftControllerActions set) { return set.Get(); }
        public void SetCallbacks(IXRLeftControllerActions instance)
        {
            if (m_Wrapper.m_XRLeftControllerActionsCallbackInterface != null)
            {
                @LeftStick.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnLeftStick;
                @Position.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnPosition;
                @Rotation.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnRotation;
                @TriggerAxis.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerAxis;
                @TriggerAxis.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerAxis;
                @TriggerAxis.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerAxis;
                @GripAxis.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripAxis;
                @GripAxis.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripAxis;
                @GripAxis.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripAxis;
                @GripButton.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripButton;
                @GripButton.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripButton;
                @GripButton.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnGripButton;
                @TriggerPress.started -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerPress;
                @TriggerPress.performed -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerPress;
                @TriggerPress.canceled -= m_Wrapper.m_XRLeftControllerActionsCallbackInterface.OnTriggerPress;
            }
            m_Wrapper.m_XRLeftControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @TriggerAxis.started += instance.OnTriggerAxis;
                @TriggerAxis.performed += instance.OnTriggerAxis;
                @TriggerAxis.canceled += instance.OnTriggerAxis;
                @GripAxis.started += instance.OnGripAxis;
                @GripAxis.performed += instance.OnGripAxis;
                @GripAxis.canceled += instance.OnGripAxis;
                @GripButton.started += instance.OnGripButton;
                @GripButton.performed += instance.OnGripButton;
                @GripButton.canceled += instance.OnGripButton;
                @TriggerPress.started += instance.OnTriggerPress;
                @TriggerPress.performed += instance.OnTriggerPress;
                @TriggerPress.canceled += instance.OnTriggerPress;
            }
        }
    }
    public XRLeftControllerActions @XRLeftController => new XRLeftControllerActions(this);
    public interface IXRRightControllerActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnTriggerAxis(InputAction.CallbackContext context);
        void OnGripAxis(InputAction.CallbackContext context);
        void OnGripButton(InputAction.CallbackContext context);
        void OnTriggerPress(InputAction.CallbackContext context);
    }
    public interface IXRLeftControllerActions
    {
        void OnLeftStick(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnTriggerAxis(InputAction.CallbackContext context);
        void OnGripAxis(InputAction.CallbackContext context);
        void OnGripButton(InputAction.CallbackContext context);
        void OnTriggerPress(InputAction.CallbackContext context);
    }
}
