using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IniciarBatllaJefe : MonoBehaviour
{
    [SerializeField] private GameObject jefePrefab;
    [SerializeField] private Transform posisionAparicion;
    public GameObject barraDeVida;
    [SerializeField] private BossFightLife barraDeVidaUI;
    [SerializeField] private bool batallaIniciada;

    private void iniciarBatlla(){
        if (batallaIniciada) return;

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
}
