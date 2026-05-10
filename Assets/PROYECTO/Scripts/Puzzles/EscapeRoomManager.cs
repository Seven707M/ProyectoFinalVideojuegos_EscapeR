using UnityEngine;
using UnityEngine.Events;

public class EscapeRoomManager : MonoBehaviour
{
    [Header("Configuración Global")]
    [Tooltip("Puzzles Actuales del Juego")]
    public int totalPuzzles = 4;
    
    private int solvedPuzzles = 0;

    [Header("Evento de Victoria Final")]
    [Tooltip("Esto se ejecutará cuando TODOS los puzzles se resuelvan")]
    public UnityEvent onEscapeRoomCompleted;
    public void AddSolvedPuzzle()
    {
        solvedPuzzles++;
        Debug.Log($"Progreso global: {solvedPuzzles} / {totalPuzzles} puzzles resueltos.");

        if (solvedPuzzles >= totalPuzzles)
        {
            Debug.Log("¡TODOS LOS PUZZLES RESUELTOS! Abriendo la puerta principal...");
            onEscapeRoomCompleted.Invoke();
        }
    }
}