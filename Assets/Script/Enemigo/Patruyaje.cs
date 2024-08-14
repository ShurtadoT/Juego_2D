using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patruyaje : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMin;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    public bool debePerseguir;
    public float distanciaPlayer;
    private GameObject player;

    private void Start(){
        numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
        debePerseguir = false;
        player = GameObject.Find("Player");
    }

    private void Update(){
        if(Vector3.Distance(gameObject.transform.position,player.GetComponent<Transform>().position) < distanciaPlayer){
            debePerseguir = true;
        }else{
            debePerseguir = false;
        }
        if(debePerseguir == false){
            transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
            if(Vector2.Distance(transform.position, puntosMovimiento[numeroAleatorio].position) < distanciaMin){
                numeroAleatorio = Random.Range(0, puntosMovimiento.Length);
                //Girar
                Girar();
            }
        }else{
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<Transform>().position, velocidadMovimiento * Time.deltaTime);
        }
    }

    private void Girar(){
        if(transform.position.x < puntosMovimiento[numeroAleatorio].position.x){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
    }
}
