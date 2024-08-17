using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenciaObjeto : MonoBehaviour
{
    private static bool creado = false;

    private void Awake()
    {
        if (!creado)
        {
            DontDestroyOnLoad(gameObject);
            creado = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
