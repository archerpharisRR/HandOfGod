using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IXRControllerInterface
{
    public Vector2 GetPointerScreenPosition();
}

public class XRInputModule : PointerInputModule
{

    PlayerInput playerInput;
    PointerEventData leftControllerData;
    PointerEventData rightControllerData;

    [SerializeField] GameObject leftController;
    [SerializeField] GameObject rightController;

    IXRControllerInterface LeftControllerInterface;
    IXRControllerInterface RightControllerInterface;
    //Process(Move), Process(Drag)
    public override void Process()
    {
       
    }

    protected override void Awake()
    {
        if(playerInput == null)
        {
            playerInput = new PlayerInput();
        }
    }

    protected override void Start()
    {
        base.Start();
        LeftControllerInterface = leftController.GetComponent<IXRControllerInterface>();
        RightControllerInterface = rightController.GetComponent<IXRControllerInterface>();

        rightControllerData = new PointerEventData(eventSystem);
        leftControllerData = new PointerEventData(eventSystem);
        playerInput.XRRightController.TriggerPress.performed += RightTriggerPressed;
        playerInput.XRLeftController.TriggerPress.performed += LeftTriggerPressed;
        playerInput.XRRightController.TriggerPress.canceled += OnRightTriggerReleased;
        playerInput.XRLeftController.TriggerPress.canceled += OnLeftTriggerReleased;
    }

    private void OnRightTriggerReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerPressed(RightControllerInterface, rightControllerData);
    }

    private void OnLeftTriggerReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerPressed(LeftControllerInterface, leftControllerData);
    }

    void OnTriggerReleased(IXRControllerInterface controller, PointerEventData eventData)
    {
        if (controller == null || eventData == null)
        {
            return;
        }
        eventData.position = RightControllerInterface.GetPointerScreenPosition();
        List<RaycastResult> rayCastResult = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, rayCastResult);
        eventData.pointerCurrentRaycast = FindFirstRaycast(rayCastResult);

        ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerUpHandler)




    }

    void OnTriggerPressed(IXRControllerInterface controller, PointerEventData eventData)
    {
        if (controller == null || eventData == null)
        {
            return;
        }

        eventData.position = RightControllerInterface.GetPointerScreenPosition();
        List<RaycastResult> rayCastResult = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, rayCastResult);
        eventData.pointerCurrentRaycast = FindFirstRaycast(rayCastResult);

        GameObject pointerDownObject = ExecuteEvents.GetEventHandler<IPointerDownHandler>(eventData.pointerCurrentRaycast.gameObject);
        if (pointerDownObject != null)
        {
            ExecuteEvents.Execute(pointerDownObject, eventData, ExecuteEvents.pointerDownHandler);
            eventData.pointerCurrentRaycast = eventData.pointerCurrentRaycast;
            eventData.eligibleForClick = true;
            eventData.pointerPress = pointerDownObject;

            ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerUpHandler);
        }
    }

    private void RightTriggerPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerPressed(RightControllerInterface, rightControllerData);
    }

    private void LeftTriggerPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerPressed(LeftControllerInterface, leftControllerData);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if(playerInput != null)
        {
            playerInput.Enable();
        }
    }

    protected override void OnDisable()
    {
        if (playerInput != null)
        {
            playerInput.Disable();
        }
        base.OnDisable();
    }




}
