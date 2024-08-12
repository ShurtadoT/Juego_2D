using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Stamina : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarStadisticaStaminaMaxima(float staminaMax){
        slider.maxValue=staminaMax;
    }

    public void CambiarStadisticaStaminaActual(float staminaActual){
        slider.value = staminaActual;
    }

    public void InicializarBarraEstadisticaStamina(float cantidadStamina){
        CambiarStadisticaStaminaActual(cantidadStamina);
        CambiarStadisticaStaminaMaxima(cantidadStamina);
    }
}
