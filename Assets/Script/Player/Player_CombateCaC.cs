using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_CombateCaC : MonoBehaviour
{
    //XP
    [Header("Xp")]
    [SerializeField] private float xp;
    [SerializeField] Player_XP_Bar barraXp;
    public int puntosXP;


    [Header("Gizmos")]
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    private Animator animator;

    //Stamina
    [Header("Stamina")]
    [SerializeField] private float stamina;
    [SerializeField] private float staminaMax;
    [SerializeField] private bool hayStamina = true;
    [SerializeField] Player_Stamina_Bar barraStamina;
    
    private void Start(){
        animator = GetComponent<Animator>();
        barraXp.CambiarXPMaxima(100);
        stamina = staminaMax;
        stamina -= 1; 
        barraStamina.CambiarStaminaMaxima(staminaMax);

        //CampoPruebasEstadisticas
        puntosXP=100;
    }

    private void Update(){

        recibirXp(Time.deltaTime);

        hayStaminaUsar();
        RecuperarStamina();
        if(tiempoSiguienteAtaque > 0){
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0 && hayStamina){
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }


    private void Golpe(){
        stamina-=20;
        barraStamina.CambiarExtamaniaActual(stamina);
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos){
            if(colisionador.CompareTag("Enemigo")){
                colisionador.transform.GetComponent<Enemigo_Vida>().TomarDaño(dañoGolpe);
            }
        } 
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private void hayStaminaUsar(){
        if(stamina>20){
            hayStamina = true;
        }else{
            hayStamina = false;
        }

    }

    private void RecuperarStamina(){
        if(stamina<staminaMax){
            stamina+=Time.deltaTime*3;
            barraStamina.CambiarExtamaniaActual(stamina);
        }
    }

    public void recibirXp(float xpRecivida){
        if((xpRecivida+xp)>=100){
            puntosXP+=1;
            xp = (xpRecivida+xp)-100;
            barraXp.CambiarXPActual(xp);
        }else{
            xp += xpRecivida;
            barraXp.CambiarXPActual(xp);
        }
    }

    public float getDaño(){
        return dañoGolpe;
    }

    public void setDaño(){
        dañoGolpe += 1;
    }

    public float getStamina(){
        return stamina;
    }

    public void SetStamina(){
        staminaMax += 1;
        barraStamina.CambiarStaminaMaxima(staminaMax);
    }

    public void SetStamina(float cant){
        if((cant+stamina)>staminaMax){
            stamina = staminaMax;
        }else{
            stamina += cant;
        }
        barraStamina.CambiarExtamaniaActual(stamina);
    }

    public void SetXp(){
        puntosXP-=1;
    }


}
