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
    public GameObject nota1;
    public AudioClip sonidoNota;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            nota1.SetActive(true);
            audioSource.PlayOneShot(sonidoNota);
            isSolved = true;

            onPuzzleSolved.Invoke(); 
            
            entradaJugador.Clear(); 
        }
    }
}