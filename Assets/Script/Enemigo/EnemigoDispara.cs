using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemigoDispara : MonoBehaviour
{
    public GameObject bala;
    public Transform balaPosision;
    private Animator animator;
    public float tiempo;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distancia = Vector2.Distance(transform.position, player.transform.position);

        if(distancia < 10){
            tiempo += Time.deltaTime;

            // Activar la animación de disparo
            animator.SetTrigger("Disparo");

            // No se llama a Disparo() aquí, se hará en el frame deseado con Animation Event
        }
    }

    // Esta función se llamará desde un Animation Event
    public void Disparo()
    {
        Instantiate(bala, balaPosision.position, quaternion.identity);
    }
}

