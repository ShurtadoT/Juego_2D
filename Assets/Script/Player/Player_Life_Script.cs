using System.Collections;
using UnityEngine;
using System;

public class Player_Life_Script : MonoBehaviour
{
    [Header("Barra de vida")]
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private Player_Life_Bar barraVida;

    private Player_Movimiento movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;
    private Rigidbody2D rb;

    //Pantalla de la muerte
    public event EventHandler muerteJugador;
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        movimientoJugador = GetComponent<Player_Movimiento>();
        animator = GetComponent<Animator>();
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    public void TomarDaño(float daño){
        if(vida > 0){
            animator.SetTrigger("GolpeRc");
            vida -= daño;
            barraVida.CambiarVidaActual(vida);
        }else{
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muere");
            Physics2D.IgnoreLayerCollision(6,8,true);
        }
    }

    public void Destruir(){
        Destroy(gameObject);
    }

    public void TomarDaño(float daño, Vector2 posicion){
        if(vida > 0){
            animator.SetTrigger("GolpeRc");
            StartCoroutine(PerderControl());
            movimientoJugador.Rebote(posicion);
            TomarDaño(daño);
        }else{
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muere");
        }
    }

    public void MuerteEventoJugador(){
        muerteJugador?.Invoke(this, EventArgs.Empty);
    }

    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

    public void Curar(float vidaExtra){
        if(vida + vidaExtra > maximoVida){
            vida = maximoVida;
        } else {
            vida += vidaExtra;
        }
        barraVida.CambiarVidaActual(vida);
    }

    public float GetVida(){
        return vida;
    }

    public void SetVida(float valor){
        vida = valor; 
        barraVida.CambiarVidaActual(vida);
    }

    public float GetMaximoVida(){
        return maximoVida;
    }

    public void SetMaxVida(float valor){
        maximoVida = valor;
        barraVida.CambiarVidaMAxima(maximoVida);
    }
}
