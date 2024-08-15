using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina_Bar : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarStaminaMaxima(float staminaMax){
        slider.maxValue = staminaMax;
    }

    public void CambiarStaminaActual(float cantidadStamina){
        slider.value = cantidadStamina;
    }

    public void InicializarBarraStamina(float stmaina){
        CambiarStaminaMaxima(stmaina);
        CambiarStaminaActual(stmaina);
    }
}
