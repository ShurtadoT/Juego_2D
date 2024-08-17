using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IniciarBatllaJefe : MonoBehaviour
{
    [SerializeField] private GameObject jefePrefab;
    [SerializeField] private Transform posisionAparicion;
    public GameObject barraDeVida;
    [SerializeField] private BossFightLife barraDeVidaUI;
    [SerializeField] private bool batallaIniciada;
    [Header("Columnas")]
    public GameObject clm1;
    public GameObject clm2;
    private void iniciarBatlla(){
        if (batallaIniciada) return;

        clm1.SetActive(true);
        clm2.SetActive(true);
        batallaIniciada = true;
        barraDeVida.SetActive(true);
        GameObject jefeInstanciado = Instantiate(jefePrefab, posisionAparicion.position, Quaternion.identity);
        Jefe jefeScript = jefeInstanciado.GetComponent<Jefe>();
        jefeScript.setBarraVida(barraDeVidaUI);
    }



    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            iniciarBatlla();
        }
    }

    private void Update(){
        if(barraDeVidaUI.slider.minValue <= 1){
            Destroy(clm1);
            Destroy(clm2);
        }
    }

}
