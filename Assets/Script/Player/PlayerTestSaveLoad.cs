using Unity.VisualScripting;
using UnityEngine;

public class PlayerTestSaveLoad : MonoBehaviour
{
    private SaveLoadSystem saveLoadSystem;
    public bool puedeGuardar = false;
    private void Start()
    {
        saveLoadSystem = GetComponent<SaveLoadSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && puedeGuardar)
        {
            saveLoadSystem.GuardarDatos(GetComponent<Player_Life_Script>().GetVida(),GetComponent<Player_Life_Script>().GetMaximoVida()
            ,GetComponent<Player_CombateCaC>().getDaño(),GetComponent<Player_CombateCaC>().getMaxStamina(),
            GetComponent<Player_CombateCaC>().getXp(),GetComponent<Player_CombateCaC>().puntosXP,transform.position);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveLoadSystem.CargarDatos();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("PuntoGuardado")){
            puedeGuardar = !puedeGuardar;
        }
    }
        private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("PuntoGuardado")){
            puedeGuardar = !puedeGuardar;
        }
    }
}
