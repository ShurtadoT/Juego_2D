using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HabilidadJefe : MonoBehaviour
{
    [SerializeField] private float daño;
    [SerializeField] private Vector2 dimensionCaja;
    [SerializeField] private Transform posisionCaja;
    [SerializeField] private float tiempoVida;

    private void Start(){
        Destroy(gameObject, tiempoVida);
    }

    public void Golpe(){
        Collider2D[] objetos = Physics2D.OverlapBoxAll(posisionCaja.position,dimensionCaja, 0f);
        foreach (Collider2D  colisiones in objetos){
            if(colisiones.CompareTag("Player")){
                colisiones.GetComponent<Player_Life_Script>().TomarDaño(daño);
            }
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(posisionCaja.position,dimensionCaja);
    }
}
