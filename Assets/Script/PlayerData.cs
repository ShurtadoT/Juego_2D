using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public float vida;
    public float maximoVida;
    public float stamina;
    public float maximoStamina;
    public float xp;
    public float maximoXP;
    public float[] posicion;

    public PlayerData(Player_Life_Script playerLifeScript, Player_Stamina_Bar playerStaminaBar, Player_XP_Bar playerXPBar, Transform playerTransform)
    {
        vida = playerLifeScript.GetVida();
        maximoVida = playerLifeScript.GetMaximoVida();
        stamina = playerStaminaBar.slider.value;
        maximoStamina = playerStaminaBar.slider.maxValue;
        xp = playerXPBar.slider.value;
        maximoXP = playerXPBar.slider.maxValue;

        posicion = new float[3];
        posicion[0] = playerTransform.position.x;
        posicion[1] = playerTransform.position.y;
        posicion[2] = playerTransform.position.z;
    }
}
