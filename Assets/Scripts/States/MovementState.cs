using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    float defaultFallingDelay = .2f;
    float fallingDelay = 0;

    public override void EnterState(AvatarController controller){
        base.EnterState(controller);
        fallingDelay = defaultFallingDelay;
    }

    public override void HandleMovement(Vector2 input){
        base.HandleMovement(input);
        controllerRef.movement.HandleMovement(input);
    }

    public override void HandleCameraDirection(Vector3 input){
        base.HandleCameraDirection(input);
        controllerRef.movement.HandleMovementDirection(input);
    }

    public override void HandleJumpInput(){
        controllerRef.TransitionToState(controllerRef.jumpState);
    }

    public override void HandleInventoryInput(){
        base.HandleInventoryInput();
        controllerRef.TransitionToState(controllerRef.inventoryState);
    }

    public override void Update(){
        base.Update();
        HandleMovement(controllerRef.input.MovementInputVector);
        HandleCameraDirection(controllerRef.input.MovementDirectionVector);
        if(controllerRef.movement.IsGrounded() == false){
            if(fallingDelay > 0){
                fallingDelay -= Time.deltaTime;
                return;
            }
            controllerRef.TransitionToState(controllerRef.fallingState);
        } else {
            fallingDelay = defaultFallingDelay;
        }
    }
}
