using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStorageButtonsHelper : MonoBehaviour
{
    public Action OnUseButtonClick, OnDropButtonClick;

    public Button useBtn, dropBtn;
    void Start()
    {
        useBtn.onClick.AddListener(() => OnUseButtonClick?.Invoke());
        dropBtn.onClick.AddListener(() => OnDropButtonClick?.Invoke());
    }

    public void HideAllButtons(){
        ToggleDropButton(false);
        ToggleUseButton(false);
    }

    public void ToggleDropButton(bool val){
        dropBtn.interactable = val;
    }

    public void ToggleUseButton(bool val){
        useBtn.interactable = val;
    }
}
