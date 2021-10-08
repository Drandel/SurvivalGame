using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : BaseState
{
    public override void EnterState(AvatarController controller){
        base.EnterState(controller);
        Debug.Log("Open Inventory");
        controllerRef.inventorySystem.ToggleInventory();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public override void HandleInventoryInput(){
        base.HandleInventoryInput();
        Debug.Log("Close Inventory");
        controllerRef.inventorySystem.ToggleInventory();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controllerRef.TransitionToState(controllerRef.movementState);
    }
}
