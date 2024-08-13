using System.Collections;
using UnityEngine;

public class Player_Life_Script : MonoBehaviour
{
    [Header("Barra de vida")]
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private Player_Life_Bar barraVida;

    private Player_Movimiento movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    private void Start(){
        movimientoJugador = GetComponent<Player_Movimiento>();
        animator = GetComponent<Animator>();
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    public void TomarDaño(float daño){
        vida -= daño;
        barraVida.CambiarVidaActual(vida);
        if(vida <= 0){
            Destroy(gameObject);
        }
    }

    public void TomarDaño(float daño, Vector2 posicion){
        animator.SetTrigger("GolpeRc");
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
        TomarDaño(daño);
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
