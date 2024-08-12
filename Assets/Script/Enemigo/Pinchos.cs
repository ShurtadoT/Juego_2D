using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    [SerializeField] private float daño;
    [SerializeField] private float tiempoEntreDaño;
    [SerializeField] private float tiempoSiguienteDaño;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Player_Life_Script>().TomarDaño(20, other.GetContact(0).normal);
        }
    }
}
