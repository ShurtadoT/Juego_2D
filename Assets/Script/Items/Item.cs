using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameObject player;
    public int id;
    public string type;
    public string description;
    public int cantidad;
    public Sprite icon;
    public string iconName;
    
    [HideInInspector]
    public bool pickedUp;

    private void Start(){
        player = GameObject.Find("Player");
    }

    public void ItemUse(){
        player = GameObject.Find("Player");
        if(id == 1){
            player.GetComponent<Player_Life_Script>().Curar(25);
        }
        if(id == 2){
            player.GetComponent<Player_Life_Script>().Curar(50);
        }
        if(id == 3){
            player.GetComponent<Player_Life_Script>().Curar(100);
        }
        if(id == 4){
            player.GetComponent<Player_CombateCaC>().SetStamina(25);
        }
        if(id == 5){
            player.GetComponent<Player_CombateCaC>().SetStamina(50);
        }
        if(id == 6){
            player.GetComponent<Player_CombateCaC>().SetStamina(100);
        }
        cantidad-=1;
    }



}
