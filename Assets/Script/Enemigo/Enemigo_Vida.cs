using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Vida : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño){
        vida -= daño;

        if(vida < 0){
            Muerte();
        }
    }

    private void Muerte(){
        animator.SetTrigger("Murio");
        StartCoroutine(DestruirDespuesDeMuerte());
    }

    private IEnumerator DestruirDespuesDeMuerte() {
        AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float duracionAnimacion = animStateInfo.length;
    
        yield return new WaitForSeconds(duracionAnimacion);
    
        Destroy(gameObject);
    }
}
