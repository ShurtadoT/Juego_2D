using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    private bool inventory_enable;
    public GameObject inventory;
    private int allSlots;
    private int enableSlots;
    private GameObject[] slot;
    public GameObject slotHolder;




    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i]=slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            inventory_enable = !inventory_enable;
        }

        if(inventory_enable){
            inventory.SetActive(true);
        }else{
            inventory.SetActive(false);
        }
    }
}
