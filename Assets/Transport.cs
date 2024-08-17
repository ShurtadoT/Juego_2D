using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform posision;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            other.transform.position = posision.position;
        }
    }
}
