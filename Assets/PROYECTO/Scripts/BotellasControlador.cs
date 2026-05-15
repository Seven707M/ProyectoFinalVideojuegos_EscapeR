using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotellasControlador : MonoBehaviour
{
    [Header("Configuración del Puzzle")]
    public List<XRSocketInteractor> sockets; 
    public List<string> ordenCorrectoTags;   

    public void VerificarOrden()
    {
        int aciertos = 0;

        for (int i = 0; i < sockets.Count; i++)
        {
            // Verificamos qué objeto tiene seleccionado el socket
            var interactuable = sockets[i].GetOldestInteractableSelected();

            if (interactuable != null)
            {
                // Comparamos el Tag del objeto con nuestra lista de solución
                if (interactuable.transform.CompareTag(ordenCorrectoTags[i]))
                {
                    aciertos++;
                }
            }
        }

        // Si el número de aciertos es igual al total de sockets
        if (aciertos == sockets.Count)
        {
            Debug.Log("¡Excelente! Las 4 botellas están en el orden correcto.");
            ResolverPuzzle();
        }
        else
        {
            Debug.Log("Aún falta algo o el orden es incorrecto. Aciertos: " + aciertos);
        }
    }

    void ResolverPuzzle()
    {
    
    }
}
