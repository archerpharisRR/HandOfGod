using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] XRHand rightHand;
    [SerializeField] XRHand leftHand;
    [SerializeField] Interaction interact;



     private void Awake()
    {
        if(playerInput == null)
        {
            playerInput = new PlayerInput();
        }
    }

    private void OnEnable()
    {
        playerInput?.Enable();
    }

    private void OnDisable()
    {
        playerInput?.Disable();
    }

    private void Start()
    {
        playerInput.XRRightController.Position.performed += ctx => rightHand.UpdateLocalPosition(ctx.ReadValue<Vector3>());
        playerInput.XRRightController.Rotation.performed += ctx => rightHand.UpdateLocalRotation(ctx.ReadValue<Quaternion>());
        playerInput.XRRightController.TriggerAxis.performed += ctx => rightHand.SetTriggerValue(ctx.ReadValue<float>());
        playerInput.XRRightController.TriggerAxis.performed += ctx => rightHand.Point();
        playerInput.XRRightController.GripAxis.performed += ctx => rightHand.SetGripValue(ctx.ReadValue<float>());
        playerInput.XRRightController.GripButton.performed += _ => interact.GrabItem();
        playerInput.XRRightController.GripButton.canceled += _ => interact.ReleaseItem();
    }




}
