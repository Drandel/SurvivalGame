using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    bool landingTriggered = false;
    float delay = 0;

    public override void EnterState(AvatarController controller){
        base.EnterState(controller);
        delay = .2f;
        landingTriggered = false;
        controllerRef.avatarAnimations.ResetTriggerlandingAnimation();
        controllerRef.movement.HandleJump();
    }

    public override void Update(){
        base.Update();
        if(delay > 0){
            delay -= Time.deltaTime;
            return;
        }
        if(controllerRef.movement.IsGrounded()){
            if(landingTriggered == false){
                landingTriggered = true;
                controllerRef.avatarAnimations.TriggerlandingAnimation();
            }
            if(controllerRef.movement.HasFinishedJumping()){
                controllerRef.TransitionToState(controllerRef.movementState);
            }
        }
    }
}
