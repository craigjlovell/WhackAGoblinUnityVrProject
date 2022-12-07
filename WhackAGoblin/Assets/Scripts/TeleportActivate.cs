using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActivate : MonoBehaviour
{
    // Access the GameObject that contains the teleport controller script.
    public GameObject teleportControllerl;

    // Reference to the Input Action Reference that contains the button mapping data for activation.
    public InputActionReference teleportActivateRefrence;

    [Space]
    [Header("Teleport Events")]
    // These will group Unity event calls that you can add to in the inspector 
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    // Start is called before the first frame update
    void Start()
    {
        // an interaction with the TeleportActivationRefrenence has been completed and performs a callback to the teleportModeActivate
        teleportActivateRefrence.action.performed += TeleportModeActivate;

        // an interaction with the TeleportActivationRefrenence has been cancelled and performs a callback to the teleportModeCancel
        teleportActivateRefrence.action.canceled += TeleportModeCancel;
    }

    // this will let us call a series of events created in the onTeleportActivate events in the inspector
    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();

    // this will delay the call of the DelayTeleportation function for 0.1 of a second
    private void TeleportModeCancel(InputAction.CallbackContext obj) => Invoke("DelayTeleportation", .1f);

    // this will let us call a series of events created in the onTeleportCancel events in inspector
    private void DelayTeleportation() => onTeleportCancel.Invoke();

    // Update is called once per frame
    void Update()
    {
        
    }
}
