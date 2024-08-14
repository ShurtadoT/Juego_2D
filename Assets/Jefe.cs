using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb;
    public Transform jugador;
    [SerializeField ]private bool mirandoDerecha = false;

    [Header("Vida")]
    public float vida;
    [SerializeField] private BossFightLife barraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        barraDeVida.InicializarBarraVida(vida);
    }

    private void Update(){
        float distanciaJugador = Vector2.Distance(transform.position,jugador.position);
        animator.SetFloat("distanciaJugador",distanciaJugador);
        MirarJugador();
    }

    public void TomarDaño(float daño){
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0){
            animator.SetTrigger("Muerte");
        }
    }

    private void Muerte(){
        Destroy(gameObject);
    }

    public void MirarJugador(){
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x <  transform.position.x && mirandoDerecha)){
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque(){
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player")){
                colision.GetComponent<Player_Life_Script>().TomarDaño(dañoAtaque);
            }
            
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorAtaque.position,radioAtaque);
    }
}
