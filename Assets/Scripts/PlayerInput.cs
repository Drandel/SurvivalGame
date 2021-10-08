﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MovementInputVector { get; private set; }
    public Vector3 MovementDirectionVector { get; private set; }
    public Action OnJump { get; set; }
    public Action OnToggleInventory { get; set; }
    public Action<int> OnHotbarKey { get; set; }
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        GetMovementInput();
        GetMovementDirection();
        GetJumpInput();
        GetInventoryInput();
        GetHotbarInput();
    }

    private void GetMovementInput() {
        MovementInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void GetMovementDirection () {
        var cameraForwardDirection = mainCamera.transform.forward;
        MovementDirectionVector = Vector3.Scale(cameraForwardDirection, (Vector3.right+Vector3.forward));
    }

    private void GetJumpInput(){
        if(Input.GetAxisRaw("Jump") > 0){
            OnJump?.Invoke();
        }
    }

    private void GetInventoryInput(){
        if(Input.GetKeyDown(KeyCode.I)){
            OnToggleInventory?.Invoke();
        }
    }

    private void GetHotbarInput()
    {
        char hotbar0 = '0';
        for (int i = 0; i < 10; i++)
        {
            KeyCode keyCode = (KeyCode)((int)hotbar0 + i);
            if (Input.GetKeyDown(keyCode))
            {
                OnHotbarKey?.Invoke(i);
                return;
            }
        }
    }
}

