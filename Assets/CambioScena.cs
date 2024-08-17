using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioScena : MonoBehaviour
{
    // Especifica el nombre de la escena a la que quieres cambiar
    public string nombreEscena;
    private GameObject player;
    private GameObject inventario;
    private GameObject barrasVidaJugador;
    private GameObject muerteJugador;

    // Si es por colisión o trigger
    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        inventario = GameObject.FindGameObjectWithTag("Inventario");
        barrasVidaJugador = GameObject.FindGameObjectWithTag("Barras");
        muerteJugador = GameObject.FindGameObjectWithTag("MuerteJugador");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica que el objeto sea el jugador
        {
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(inventario);
            DontDestroyOnLoad(barrasVidaJugador);
            DontDestroyOnLoad(muerteJugador);
            DontDestroyOnLoad(gameObject); 
            SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
        }
    }
}
