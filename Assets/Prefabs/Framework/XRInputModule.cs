using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
        playerInput.XRRightController.Position.performed += OnRightTriggerMoved;
        playerInput.XRLeftController.Position.performed += OnLeftTriggerMoved;
    }

    void OnTriggerMoved(IXRControllerInterface controller, PointerEventData eventData)
    {
        if(controller == null || eventData == null)
        {
            return;
        }
        eventData.position = controller.GetPointerScreenPosition();
        //List<RaycastResult> rayCastResult = new List<RaycastResult>();
        //eventSystem.RaycastAll(eventData, rayCastResult);
        //eventData.pointerCurrentRaycast = FindFirstRaycast(rayCastResult);
        ProcessMove(eventData);
        if (eventData.dragging)
        {
            ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.dragHandler);
        }
    }

    private void OnRightTriggerMoved(InputAction.CallbackContext obj)
    {
        OnTriggerMoved(RightControllerInterface, rightControllerData);
    }

    private void OnLeftTriggerMoved(InputAction.CallbackContext obj)
    {
        OnTriggerMoved(LeftControllerInterface, leftControllerData);
    }



    private void OnRightTriggerReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerReleased(RightControllerInterface, rightControllerData);
    }

    private void OnLeftTriggerReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnTriggerReleased(LeftControllerInterface, leftControllerData);
    }

    void OnTriggerReleased(IXRControllerInterface controller, PointerEventData eventData)
    {
        if (controller == null || eventData == null)
        {
            return;
        }
        eventData.position = controller.GetPointerScreenPosition();
        List<RaycastResult> rayCastResult = new List<RaycastResult>();
        eventSystem.RaycastAll(eventData, rayCastResult);
        eventData.pointerCurrentRaycast = FindFirstRaycast(rayCastResult);

        ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerUpHandler);
        GameObject currentPointerDown = ExecuteEvents.GetEventHandler<IPointerDownHandler>(eventData.pointerCurrentRaycast.gameObject);
        if (eventData.pointerPress == currentPointerDown)
        {
            ExecuteEvents.Execute(eventData.pointerPress, eventData, ExecuteEvents.pointerClickHandler);
        }
        eventData.pointerPress = null;

        if (eventData.dragging)
        {
            ExecuteEvents.Execute(eventData.pointerDrag, eventData, ExecuteEvents.endDragHandler);
            eventData.pointerDrag = null;
            eventData.dragging = false;
        }


    }

    void OnTriggerPressed(IXRControllerInterface controller, PointerEventData eventData)
    {
        if (controller == null || eventData == null)
        {
            return;
        }

        eventData.position = controller.GetPointerScreenPosition();
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

            
        }
        GameObject pointderDragObject = ExecuteEvents.GetEventHandler<IDragHandler>(eventData.pointerCurrentRaycast.gameObject);

        if (pointderDragObject != null)
        {
            ExecuteEvents.Execute(pointderDragObject, eventData, ExecuteEvents.initializePotentialDrag);
            eventData.pointerCurrentRaycast = eventData.pointerCurrentRaycast;
            eventData.dragging = true;
            eventData.pointerDrag = pointderDragObject;
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
