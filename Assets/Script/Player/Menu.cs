using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject menu;
    private Player_Life_Script vidaJugador;

    private void Start(){
        vidaJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Life_Script>();
        vidaJugador.muerteJugador += AbrirMenu;
    }

    private void AbrirMenu(object sender, EventArgs e){
        menu.SetActive(true);
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
