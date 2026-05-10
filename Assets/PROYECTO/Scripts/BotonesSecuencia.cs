using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotonesSecuencia : MonoBehaviour
{
    [Header("Configuración de Secuencia")]
    public List<GameObject> secuenciaCorrecta; 
    
    [Header("Eventos al Resolver")]
    public UnityEvent onPuzzleSolved;
    
    private List<GameObject> entradaJugador = new List<GameObject>();
    private bool isSolved = false;

    public void BotonPresionado(GameObject boton)
    {
        if (isSolved) return;

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
                Debug.Log("Secuencia Incorrecta. Reiniciando...");
                entradaJugador.Clear();
                return;
            }
        }

        if (entradaJugador.Count == secuenciaCorrecta.Count)
        {
            Debug.Log("Correcto, Primer numero '5'");
            isSolved = true;

            onPuzzleSolved.Invoke(); 
            
            entradaJugador.Clear(); 
        }
    }
}