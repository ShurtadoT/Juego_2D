using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveLoadSystem : MonoBehaviour
{
    public Player_Inventory playerInventory; // Asigna tu inventario aquí

    public void GuardarDatos(float vida, float maximoVida, float dañoGolpe, float maximoStamina, float xp, int puntosXP, Vector3 vector)
    {
        // Guarda los datos del jugador y el inventario
        List<ItemData> inventoryData = playerInventory.SaveInventory();
        PlayerData data = new PlayerData(vida, maximoVida, dañoGolpe, maximoStamina, xp, puntosXP, vector, inventoryData);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
        Debug.Log("Datos guardados en: " + Application.persistentDataPath + "/playerData.json");
    }

    public void CargarDatos()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            // Cargar los datos del jugador
            gameObject.GetComponent<Player_Life_Script>().SetVida(data.vida);
            gameObject.GetComponent<Player_Life_Script>().SetMaxVida(data.maximoVida);
            gameObject.GetComponent<Player_CombateCaC>().setDaño(data.dañoGolpe);
            gameObject.GetComponent<Player_CombateCaC>().SetStaminaMax(data.maximoStamina);
            gameObject.GetComponent<Player_CombateCaC>().SetXp(data.xp);
            gameObject.GetComponent<Player_CombateCaC>().puntosXP = data.puntosXP;
            gameObject.transform.position = data.ubicacion;

            // Cargar el inventario
            playerInventory.LoadInventory(data.inventory);
        }
    }
}
