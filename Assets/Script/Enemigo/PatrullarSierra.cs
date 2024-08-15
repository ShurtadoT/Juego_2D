using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrullarSierra : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMin;
    private int siguientePaso = 0;
    private SpriteRenderer spriteRenderer;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velocidadMovimiento * Time.deltaTime);
        if(Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < distanciaMin){
            siguientePaso += 1;
            if(siguientePaso >= puntosMovimiento.Length){
                siguientePaso = 0;
            }
        }
    }
}
