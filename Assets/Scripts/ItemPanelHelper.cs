using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanelHelper : MonoBehaviour
{
    public Action<int, bool> OnClickEvent;
    public Image itemImage;

    [SerializeField]
    private Text nameText, countText;
    public string itemName, itemCount;
    public bool isEmpty = true;
    public Outline outline;
    public bool isHotbarItem = false;
    public Sprite backgroundSprite;
    
    public void Start(){
        outline = GetComponent<Outline>();
        outline.enabled = false;
        if(itemImage.sprite == backgroundSprite){
            ClearItem();
        }
    }

    public void SetInventoryUiElement(string name, int count, Sprite image){
        itemName = name;
        itemCount = count + "";
        if(!isHotbarItem){
            nameText.text = itemName;
        }
        countText.text = itemCount;
        isEmpty = false;
        SetImageSprite(image);
    }

    public void SwapWithData(string name, int count, Sprite image, bool isEmpty){
        SetInventoryUiElement(name, count, image);
        this.isEmpty = isEmpty;
    }

    public void SetImageSprite(Sprite image){
        itemImage.sprite = image;
    }

    public void ClearItem(){
        itemName = "";
        itemCount = "";
        countText.text = itemCount;
        if(!isHotbarItem){
            nameText.text = itemName;
        }
        ResetImage();
        isEmpty = true;
        ToggleHighlight(false);
    }

    public void ResetImage(){
        itemImage.sprite = backgroundSprite;
    }

    public void ToggleHighlight(bool val){
        outline.enabled = val;
    }
}
