using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour
{

    public AvatarMovement movement;
    public PlayerInput input;
    public HumanoidAnimations avatarAnimations;

    public InventorySystem inventorySystem;

    BaseState currentState;
    public readonly BaseState movementState = new MovementState();
    public readonly BaseState jumpState = new JumpState();
    public readonly BaseState fallingState = new FallingState();
    public readonly BaseState inventoryState = new InventoryState();
    
    
    private void OnEnable(){
        movement = GetComponent<AvatarMovement>();
        input = GetComponent<PlayerInput>();
        avatarAnimations = GetComponent<HumanoidAnimations>();
        currentState = movementState;
        currentState.EnterState(this);
        AssignInputListeners();
    }

    private void AssignInputListeners(){
        input.OnJump += HandleJump;
        input.OnHotbarKey += HandleHotbarInput;
        input.OnToggleInventory += HandleInventoryInput;
    }

    private void HandleJump(){
        currentState.HandleJumpInput();
    }

    private void HandleInventoryInput(){
        currentState.HandleInventoryInput();
    }

    private void HandleHotbarInput(int hotbarKey){
        currentState.HandleHotbarInput(hotbarKey);
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
