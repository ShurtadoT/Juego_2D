using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public int cantidad;
    public Sprite icon;
    public Sprite iconDefault;

    public Transform slotIconGameObject;

    public void ClearSlot(){
        ID = 0;
        type = "";
        description = "";
        cantidad = 0;
        icon = null;
        // Lógica para limpiar visualmente el slot...
    }


    private void Start(){
        iconDefault = gameObject.GetComponent<Image>().sprite;
        slotIconGameObject=transform.GetChild(0);
    }

    public void UpdateSlot(){
        if (icon != null){
            slotIconGameObject.GetComponent<Image>().sprite = icon;
        }
        else{
            // Cargar icono desde los recursos si es necesario
            slotIconGameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + iconDefault.name);
        }
    }

    public void UserItem(){
        item.GetComponent<Item>().ItemUse();
    }

    public void ReloadSlot(){
        cantidad = item.GetComponent<Item>().cantidad;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ""+cantidad;
    }

    public void OnPointerClick(PointerEventData pointerEventData){
        if(cantidad > 0){
            UserItem();
            ReloadSlot();
        }
        if(cantidad <= 0){
            empty = true;
            Destroy(item);
            slotIconGameObject.GetComponent<Image>().sprite = iconDefault;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            ID=0;
            type = null;
            description = null;
            cantidad = 0;
        }
    }
}
