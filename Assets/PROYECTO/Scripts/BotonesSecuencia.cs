using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesSecuencia : MonoBehaviour
{
    public List<GameObject> secuenciaCorrecta; 
    
    private List<GameObject> entradaJugador = new List<GameObject>();

    public void BotonPresionado(GameObject boton)
    {
        entradaJugador.Add(boton);
        Debug.Log("Botón presionado: " + boton.name);

        CheckProgreso();
    }

    void CheckProgreso()
    {
        for (int i = 0; i < entradaJugador.Count; i++)
        {
            if (entradaJugador[i] != secuenciaCorrecta[i])
            {
                Debug.Log("Secuencia Incorrecta");
                entradaJugador.Clear();
                return;
            }
        }

        if (entradaJugador.Count == secuenciaCorrecta.Count)
        {
            Debug.Log("Correcto, Primer numero '5'");
            entradaJugador.Clear(); 
        }
    }
}
