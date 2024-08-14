using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        RaycastHit2D informacion = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad,rb.velocity.y);

        if(informacion == false){
            //Girar
            Girar();
        }


    }

    private void Girar(){
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180, 0);
        velocidad *=-1;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position+Vector3.down * distancia);
    }
}
