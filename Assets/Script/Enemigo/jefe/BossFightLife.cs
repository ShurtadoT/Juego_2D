using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightLife : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

    }
    public void CambiarVidaMax(float vidaMax){
        slider = GetComponent<Slider>();
        slider.maxValue = vidaMax;
    }

    public void CambiarVidaActual(float vida){
        slider = GetComponent<Slider>();
        slider.value = vida;
    }

    public void InicializarBarraVida(float vida){
        slider = GetComponent<Slider>();
        CambiarVidaMax(vida);
        CambiarVidaActual(vida);
    }
}
