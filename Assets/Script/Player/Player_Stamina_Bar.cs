using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stamina_Bar : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarStaminaMaxima(float staminaMax){
        slider.maxValue=staminaMax;
    }

    public void CambiarExtamaniaActual(float cantidadExtamina){
        slider.value = cantidadExtamina;
    }

    public void InicializarBarraStamina(float stamina){
        CambiarExtamaniaActual(stamina);
        CambiarStaminaMaxima(stamina);
    }
}
