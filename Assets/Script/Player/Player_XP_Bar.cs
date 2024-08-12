using UnityEngine;
using UnityEngine.UI;

public class Player_XP_Bar : MonoBehaviour
{
    public Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarXPMaxima(float xpMaxima){
        slider.maxValue = xpMaxima;
    }

    public void CambiarXPActual(float xpActual){
        slider.value = xpActual;
    }

    public void InicializarBarraXP(float cantidadXP){
        CambiarXPMaxima(cantidadXP);
        CambiarXPActual(cantidadXP);
    }
}
