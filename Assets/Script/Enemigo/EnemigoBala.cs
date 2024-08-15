using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoBala : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float fuerza;
    private float tiempo;
    public float daño;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 posision = player.transform.position - transform.position;
        rb.velocity = new Vector2(posision.x, posision.y).normalized * fuerza;

        float rot=Mathf.Atan2(-posision.y, -posision.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if(tiempo > 10){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            other.GetComponent<Player_Life_Script>().TomarDaño(daño);
        }
    }
}
