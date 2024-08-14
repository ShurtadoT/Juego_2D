using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life_Bar : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
        
    }

    public void CambiarVidaMAxima(float vidaMaxima){
        slider.maxValue=vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida){
        slider.value = cantidadVida;
    }

    public void InicializarBarraVida(float cantidadVida){
        CambiarVidaMAxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }


}
