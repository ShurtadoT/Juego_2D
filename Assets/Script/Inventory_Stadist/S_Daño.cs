using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class S_Daño : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarStadisticaDañoMaximo(float dañoMax){
        slider.maxValue = dañoMax;
    }

    public void CambiarStadisticaDañoActual(float dañoActu){
        slider.value = dañoActu;
    }

    public void InicializarBarraEstadisticaDaño(float cantidadDaño){
        CambiarStadisticaDañoActual(cantidadDaño);
        CambiarStadisticaDañoMaximo(cantidadDaño);
    }
}
