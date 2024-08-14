using UnityEngine;

public class PlayerTestSaveLoad : MonoBehaviour
{
    private SaveLoadSystem saveLoadSystem;

    private void Start()
    {
        saveLoadSystem = GetComponent<SaveLoadSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Guarda los datos del jugador
            saveLoadSystem.GuardarDatos(
                GetComponent<Player_Life_Script>().GetVida(),
                GetComponent<Player_Life_Script>().GetMaximoVida(),
                GetComponent<Player_CombateCaC>().getDaño(),
                GetComponent<Player_CombateCaC>().getMaxStamina(),
                GetComponent<Player_CombateCaC>().getXp(),
                GetComponent<Player_CombateCaC>().puntosXP,
                transform.position
            );
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveLoadSystem.CargarDatos();
        }
    }
}
