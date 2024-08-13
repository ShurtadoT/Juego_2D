using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesBoton : MonoBehaviour
{
    [SerializeField] private S_Vida vida;
    [SerializeField] private S_Stamina stamina;
    [SerializeField] private S_Daño daño;

    [SerializeField] GameObject player;


    public void SubirVida(){
        if(player.GetComponent<Player_CombateCaC>().puntosXP>0){
            player.GetComponent<Player_Life_Script>().SetMaxVida(player.GetComponent<Player_Life_Script>().GetMaximoVida()+1);
            vida.CambiarStadisticaVidaActual(player.GetComponent<Player_Life_Script>().GetVida());
            player.GetComponent<Player_CombateCaC>().SetXp();
            player.GetComponent<Player_Inventory>().puntos.text = player.GetComponent<Player_CombateCaC>().puntosXP+"";
        }
    }

    public void SubirStamina(){
        if(player.GetComponent<Player_CombateCaC>().puntosXP>0){
            player.GetComponent<Player_CombateCaC>().SetStamina();
            stamina.CambiarStadisticaStaminaActual(player.GetComponent<Player_CombateCaC>().getStamina());
            player.GetComponent<Player_CombateCaC>().SetXp();
            player.GetComponent<Player_Inventory>().puntos.text = player.GetComponent<Player_CombateCaC>().puntosXP+"";
        }
    }

    public void SubirDaño(){
        if(player.GetComponent<Player_CombateCaC>().puntosXP>0){
            player.GetComponent<Player_CombateCaC>().setDaño();
            daño.CambiarStadisticaDañoActual(player.GetComponent<Player_CombateCaC>().getDaño());
            player.GetComponent<Player_CombateCaC>().SetXp();
            player.GetComponent<Player_Inventory>().puntos.text = player.GetComponent<Player_CombateCaC>().puntosXP+"";
        }
    }


}
