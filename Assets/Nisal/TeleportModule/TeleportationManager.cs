using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField]private XRRayInteractor ray;
    [SerializeField]private InputActionAsset inputActions;
    [SerializeField]private TeleportationProvider teleportationProvider;

    private InputAction teleportActivate,teleportSelect, teleportCancel;

    RaycastHit hit;

    bool isValidHit;

    Vector3 normal; //not using
    Vector3 teleportPosition;
    int position; //not using
    
    void Start()
    {
        //need 3 input actions for the teleportation
        //teleportActivate = trigger by north navigation
        //teleportSelect = select face direction
        //teleportCancel = cancel teleport action by pressing grab button

        //Logic
        //North Button ( Activate) - raycast on - ok
        //Give up navi north (Cancel) - raycast off - ok
        //Press grip during teleport - raycast off - ok
        //End Teleport - raycast off, get position, move to position - ok

        //Navigate Face direction (Select) 
        //End Navigate Direction (Select)- get position

        ray.enabled = false;

        teleportActivate = inputActions.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        teleportActivate.Enable(); //action must be enabled before using it

        //Teleport Rotate
        // teleportSelect = inputActions.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Select");
        // teleportSelect.Enable();

        teleportCancel = inputActions.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        teleportCancel.Enable(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        teleportActivate.performed += TeleportModeActivate; //if teleport mode activated = navi north
        teleportActivate.canceled += TeleportModeCancelled; //if teleport mode ends = navi back to middle
        teleportCancel.performed += TeleportActionCancel;   //if teleport mode cencelled by pressing grip

        //teleport rotation
        //teleportSelect.performed += SelectTeleportRotation;
    }

    void TeleportModeActivate(InputAction.CallbackContext ctx)
    {
        ray.enabled = true; // ray on
    }

    // void SelectTeleportRotation(InputAction.CallbackContext ctx)
    // {
    //     Debug.Log("Here Add rotation Code");
    //     //teleportSelect.
    // }

    void TeleportModeCancelled(InputAction.CallbackContext ctx)
    {
        ray.TryGetHitInfo(out teleportPosition,out normal,out position,out isValidHit); // teleportPosition = get position to navigate, isValid= valid navigate position?

        if(isValidHit) //if valid point, then move
        {
            TeleportRequest teleportRequest = new TeleportRequest(){
            destinationPosition = teleportPosition
            };
            teleportationProvider.QueueTeleportRequest(teleportRequest);
        }
        ray.enabled = false; // ray off
        
    }

    void TeleportActionCancel(InputAction.CallbackContext ctx) // if press grip during teleport
    {
        Debug.Log("Teleport Cancelled");
        ray.enabled = false;
    }

    void OnDisable() // good practice to disable, enabled actions
    {
        teleportActivate.Disable();
        teleportCancel.Disable();
    }
    
}
