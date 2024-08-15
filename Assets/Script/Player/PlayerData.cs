using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float vida;
    public float maximoVida;
    public float dañoGolpe;
    public float maximoStamina;
    public float xp;
    public int puntosXP;
    public Vector3 ubicacion;
    public List<ItemData> inventory;

    public PlayerData(float vida,float maximoVida, float dañoGolpe, float maximoStamina,float xp,int puntosXP,Vector3 ubicacion, List<ItemData> inventory){
        this.vida = vida;
        this.maximoVida = maximoVida;
        this.dañoGolpe = dañoGolpe;
        this.maximoStamina = maximoStamina;
        this.xp = xp;
        this.puntosXP = puntosXP;
        this.ubicacion = ubicacion;
        this.inventory = inventory;
    }
}

