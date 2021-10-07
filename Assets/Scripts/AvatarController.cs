using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{

    public AvatarMovement movement;
    public PlayerInput input;
    public HumanoidAnimations avatarAnimations;

    BaseState currentState;
    public readonly BaseState movementState = new MovementState();
    public readonly BaseState jumpState = new JumpState();
    public readonly BaseState fallingState = new FallingState();
    
    
    private void OnEnable(){
        movement = GetComponent<AvatarMovement>();
        input = GetComponent<PlayerInput>();
        avatarAnimations = GetComponent<HumanoidAnimations>();
        currentState = movementState;
        currentState.EnterState(this);
        AssignMovementInputListeners();
    }

    private void AssignMovementInputListeners(){
        input.OnJump += HandleJump;
    }

    private void HandleJump(){
        currentState.HandleJumpInput();
    }

    private void OnDisable(){
        input.OnJump -= currentState.HandleJumpInput;
    }

    private void Update(){
        currentState.Update();
    }

    public void TransitionToState(BaseState state){
        currentState = state;
        currentState.EnterState(this);
    }
}
