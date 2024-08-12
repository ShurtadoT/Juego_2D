using UnityEngine;

public class PlayerTestSaveLoad : MonoBehaviour
{
    private SaveLoadSystem saveLoadSystem;
    private Player_Life_Script playerLifeScript;
    private Player_Stamina_Bar playerStaminaBar;
    private Player_XP_Bar playerXPBar;

    private void Start()
    {
        saveLoadSystem = GetComponent<SaveLoadSystem>();
        playerLifeScript = GetComponent<Player_Life_Script>();
        playerStaminaBar = FindObjectOfType<Player_Stamina_Bar>();
        playerXPBar = FindObjectOfType<Player_XP_Bar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveLoadSystem.GuardarDatos(playerLifeScript, playerStaminaBar, playerXPBar, transform);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveLoadSystem.CargarDatos(playerLifeScript, playerStaminaBar, playerXPBar, transform);
        }
    }
}
