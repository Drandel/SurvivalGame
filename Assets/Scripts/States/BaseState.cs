using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected AvatarController controllerRef;

    public virtual void EnterState(AvatarController controller){
        this.controllerRef = controller;
    }

    public virtual void HandleMovement(Vector2 input){ }

    public virtual void HandleCameraDirection(Vector3 input){ }

    public virtual void HandleJumpInput(){ }

    public virtual void HandleInventoryInput(){ }

    public virtual void HandleHotbarInput(int hotbarKey){
        Debug.Log(hotbarKey);
     }

    public virtual void Update(){ }
}
