using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class BookPuzzleManager : MonoBehaviour
{
    [Header("Sockets en orden (Izquierda a Derecha)")]
    public XRSocketInteractor[] bookSockets;

    [Header("Secuencia Correcta de IDs")]
    public int[] correctBookIDs;

    [Header("Eventos al Resolver")]
    public UnityEvent onPuzzleSolved;

    private bool isSolved = false;
    public GameObject nota2;
    public AudioClip sonidoNota;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EvaluatePuzzle()
    {
        if (isSolved) return;

        for (int i = 0; i < bookSockets.Length; i++)
        {
            XRBaseInteractable interactableInSocket = bookSockets[i].selectTarget;

            if (interactableInSocket == null) return;

            BookID book = interactableInSocket.GetComponent<BookID>();

            if (book == null || book.id != correctBookIDs[i])
            {
                return; 
            }
        }

        Debug.Log("¡Secuencia correcta! Puzzle resuelto.");
        isSolved = true;
        nota2.SetActive(true);
        audioSource.PlayOneShot(sonidoNota);
        // Ejecutamos la función para bloquear los libros
        LockBooks();

        onPuzzleSolved.Invoke(); 
    }

    // --- NUEVA FUNCIÓN ---
    private void LockBooks()
    {
        // Recorremos cada socket de la repisa
        foreach (var socket in bookSockets)
        {
            XRBaseInteractable book = socket.selectTarget;
            if (book != null)
            {
                book.interactionLayerMask = LayerMask.GetMask("bloquedBooks");
            }
        }
    }
}