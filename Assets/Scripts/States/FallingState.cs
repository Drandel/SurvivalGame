using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : JumpState
{
    public override void EnterState(AvatarController controller) {
        base.EnterState(controller);
        controllerRef.avatarAnimations.TriggerFallAnimation();
        controllerRef.movement.SetFinishedJumpingFalse();
    }

    public override void Update(){
        base.Update();
    }
}
