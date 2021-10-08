using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    public GameObject inventoryGeneralPanel;
    public bool IsInventoryVisible { get => inventoryGeneralPanel.activeSelf; }

    private void Awake(){
        inventoryGeneralPanel.SetActive(false);
    }

    public void ToggleInventory(){
        if(inventoryGeneralPanel.activeSelf == false){
            inventoryGeneralPanel.SetActive(true);
        } else {
            inventoryGeneralPanel.SetActive(false);
        }
    }
}
