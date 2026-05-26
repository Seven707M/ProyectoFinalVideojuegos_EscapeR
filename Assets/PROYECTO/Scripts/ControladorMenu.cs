using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu : MonoBehaviour
{
    // Nombre exacto de la escena del juego principal
    [SerializeField] private string nombreEscenaJuego = "EscapeRoom";

    // Método para cambiar a la escena del juego
    public void IniciarJuego()
    {
        SceneManager.LoadScene(nombreEscenaJuego);
    }

    // Método para cerrar el juego
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}