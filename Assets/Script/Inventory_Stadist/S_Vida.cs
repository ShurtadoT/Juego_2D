using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Vida : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarStadisticaVidaMaxima(float MaxVida){
        slider.maxValue = MaxVida;
    }

    public void CambiarStadisticaVidaActual(float ActVida){
        slider.value = ActVida;
    }

    public void InicializarBarraEstadisticaVida(float cantidadVida){
        CambiarStadisticaVidaActual(cantidadVida);
        CambiarStadisticaVidaMaxima(cantidadVida);
    }
}
