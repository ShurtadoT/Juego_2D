using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movimiento : MonoBehaviour
{
    private Rigidbody2D rbd2D;
    //Este comentario me la suda
    //Titulo del movimiento
    [Header("Movimiento")]

    //Movimiento personaje
    private float Movimiento_Horizontal = 0f;
    [SerializeField] private float Player_Velocidad;
    [Range(0, 0.3f)][SerializeField] private float Player_Suavizado_Movimiento;

    //Evitar que se mueva en el eje z
    private UnityEngine.Vector3 velocidad = UnityEngine.Vector3.zero;

    //Saber si mira a la derecha o a la izquierda
    private bool Player_Mirando_Derecha = true;

    //Titulo del salto
    [Header("Salto")]
    [SerializeField] private float Player_Potencia_Salto;
    [SerializeField] private LayerMask queEsSuelo;
    //OndrawGizmos
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private UnityEngine.Vector3 GizmosCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    //Animacion
    [Header("Animacion")]
    private Animator animator;


    private void Start() {
        rbd2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        Movimiento_Horizontal = Input.GetAxisRaw("Horizontal")*Player_Velocidad;

        animator.SetFloat("Horizontal",Mathf.Abs(Movimiento_Horizontal));
        animator.SetFloat("VelocidadY",rbd2D.velocity.y);

        if (Input.GetButtonDown("Jump")){
            salto = true;
        }
    }

    private void FixedUpdate() {
        //Salto
        enSuelo = Physics2D.OverlapBox(ControladorSuelo.position, GizmosCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo",enSuelo);

        //Mover
        Mover(Movimiento_Horizontal * Time.fixedDeltaTime, salto);
        salto = false;
    }

    private void Mover(float mover, bool saltar) {
        UnityEngine.Vector3 velocidadObjetivo = new UnityEngine.Vector2(mover, rbd2D.velocity.y);
        rbd2D.velocity = UnityEngine.Vector3.SmoothDamp(rbd2D.velocity, velocidadObjetivo, ref velocidad, Player_Suavizado_Movimiento);

        if (mover > 0 && !Player_Mirando_Derecha){
            //Girar
            Girar();
        }else if(mover < 0 && Player_Mirando_Derecha) {
            //Girar
            Girar();
        }

        if(enSuelo && saltar){
            enSuelo = false;
            rbd2D.AddForce(new UnityEngine.Vector2(0f, Player_Potencia_Salto));
        }

    }

    private void Girar () {
        Player_Mirando_Derecha = !Player_Mirando_Derecha;
        UnityEngine.Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(ControladorSuelo.position, GizmosCaja);
    }
}
