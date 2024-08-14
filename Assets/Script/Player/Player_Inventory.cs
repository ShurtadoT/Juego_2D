using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Player_Inventory : MonoBehaviour
{
    private bool inventory_enable;
    public GameObject inventory;
    private int allSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    public TextMeshProUGUI puntos;
    public TextMeshProUGUI oroCifra;

    // Estadísticas
    [Header("Barras Estadísticas")]
    [SerializeField] private S_Vida BarraVida;
    [SerializeField] private S_Stamina BarraStamina;
    [SerializeField] private S_Daño BarraDaño;

    // Oro
    public float oro;

    //Congelar
    private bool esPausa = false;

    private Item[] items;
    public GameObject[] prefabsItems;

    public List<Slot> slots;

    private void Pausa(){
        if(esPausa){
            Time.timeScale = 1f;
            esPausa = false;
        }else{
            Time.timeScale = 0f;
            esPausa = true;
        }
    }

    // Método para guardar el inventario
    public List<ItemData> SaveInventory()
    {
        List<ItemData> inventoryData = new List<ItemData>();

        for (int i = 0; i < allSlots; i++)
        {
            Item item = new Item();
            if(slot[i] != null && slot[i].GetComponent<Slot>().empty == false){
                item.id = slot[i].GetComponent<Slot>().ID;
                item.type = slot[i].GetComponent<Slot>().type;
                item.description = slot[i].GetComponent<Slot>().description;
                item.cantidad = slot[i].GetComponent<Slot>().cantidad;
                item.icon = slot[i].GetComponent<Slot>().icon;
                ItemData data = new ItemData(item.id, item.type, item.description, item.cantidad, item.icon.name);
                inventoryData.Add(data);
            }
        }
        return inventoryData;
    }

    // Método para cargar el inventario
    public void LoadInventory(List<ItemData> inventoryData)
    {
        for (int i = 0; i < allSlots; i++)
        {
            slot[i].GetComponent<Slot>().ClearSlot();
        }

        for (int i = 0; i < inventoryData.Count; i++)
        {
            bool encontrado = false;
            if(slot[i].GetComponent<Slot>() != null && slot[i].GetComponent<Slot>().empty){
                GameObject itemCargado = null;
                for (int j = 0; j < prefabsItems.Length; j++)
                {
                    if(inventoryData[i].id == prefabsItems[j].GetComponent<Item>().id){
                        encontrado = true;
                        itemCargado = Instantiate(prefabsItems[j]);
                    }
                }
                if (encontrado)
                {
                    AddItem(itemCargado,inventoryData[i].id,inventoryData[i].type,inventoryData[i].description,itemCargado.GetComponent<Item>().icon,inventoryData[i].cantidad);
                    encontrado = false;
                }
            }
        }
    }

    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        items = new Item[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory_enable = !inventory_enable;
            if (inventory_enable)
            {
                puntos.text = gameObject.GetComponent<Player_CombateCaC>().puntosXP.ToString();

                BarraVida.CambiarStadisticaVidaMaxima(999);
                BarraVida.CambiarStadisticaVidaActual(GetComponent<Player_Life_Script>().GetVida());

                BarraStamina.CambiarStadisticaStaminaMaxima(999);
                BarraStamina.CambiarStadisticaStaminaActual(GetComponent<Player_CombateCaC>().getStamina());

                BarraDaño.CambiarStadisticaDañoMaximo(999);
                BarraDaño.CambiarStadisticaDañoActual(GetComponent<Player_CombateCaC>().getDaño());
            }
            Pausa();
        }

        inventory.SetActive(inventory_enable);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            GameObject itempickedUp = other.gameObject;
            Item item = itempickedUp.GetComponent<Item>();
            AddItem(itempickedUp, item.id, item.type, item.description, item.icon, item.cantidad);
        }
        if (other.tag == "oro")
        {
            GameObject itempickedUp = other.gameObject;
            oro += other.GetComponent<Item>().cantidad;
            Destroy(itempickedUp);
            oroCifra.text = oro.ToString();
        }
    }

    public void AddItem(GameObject itemObject, int item_ID, String itemType, string itemDescription, Sprite itemIcon, int itemCantidad)
    {
        bool bandera = false;
        for (int i = 0; i < allSlots; i++)
        {
            if(!slot[i].GetComponent<Slot>().empty && slot[i].GetComponent<Slot>().ID == item_ID){
                slot[i].GetComponent<Slot>().cantidad += itemCantidad;
                slot[i].GetComponent<Transform>().GetChild(2).GetComponent<Item>().cantidad += itemCantidad;
                slot[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = slot[i].GetComponent<Transform>().GetChild(2).GetComponent<Item>().cantidad.ToString();
                Destroy(itemObject);
                bandera = true;
            }
        }
        if(bandera == false){
            for (int i = 0; i < allSlots; i++)
            {

                if (slot[i].GetComponent<Slot>().empty)
                {
                    itemObject.GetComponent<Item>().pickedUp = true;

                    slot[i].GetComponent<Slot>().item = itemObject;
                    slot[i].GetComponent<Slot>().ID = item_ID;
                    slot[i].GetComponent<Slot>().type = itemType;
                    slot[i].GetComponent<Slot>().description = itemDescription;
                    slot[i].GetComponent<Slot>().icon = itemIcon;
                    slot[i].GetComponent<Slot>().cantidad = itemCantidad;
                    slot[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemCantidad.ToString();

                    itemObject.transform.parent = slot[i].transform;
                    itemObject.SetActive(false);

                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().empty = false;
                    return;
                }
            }

        }

    }
}
