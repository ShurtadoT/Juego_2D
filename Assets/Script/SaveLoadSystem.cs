using UnityEngine;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    public void GuardarDatos(Player_Life_Script playerLifeScript, Player_Stamina_Bar playerStaminaBar, Player_XP_Bar playerXPBar, Transform playerTransform)
    {
        PlayerData data = new PlayerData(playerLifeScript, playerStaminaBar, playerXPBar, playerTransform);
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
        Debug.Log("Datos guardados en: " + Application.persistentDataPath + "/playerData.json");
    }

    public void CargarDatos(Player_Life_Script playerLifeScript, Player_Stamina_Bar playerStaminaBar, Player_XP_Bar playerXPBar, Transform playerTransform)
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerLifeScript.SetVida(data.vida);
            playerLifeScript.SetMaxVida(data.maximoVida);
            playerStaminaBar.InicializarBarraStamina(data.stamina);
            playerXPBar.InicializarBarraXP(data.xp);

            Vector3 posicion = new Vector3(data.posicion[0], data.posicion[1], data.posicion[2]);
            playerTransform.position = posicion;

            Debug.Log("Datos cargados desde: " + path);
        }
        else
        {
            Debug.LogWarning("No se encontró ningún archivo de guardado.");
        }
    }
}
