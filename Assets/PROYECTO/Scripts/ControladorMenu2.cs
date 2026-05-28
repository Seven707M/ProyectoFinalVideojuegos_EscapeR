using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenu2 : MonoBehaviour
{
    // Nombre exacto de la escena del menú principal
    [SerializeField] private string nombreEscenaMenu = "Menu";

    // Método para regresar a la escena del menú
    public void RegresarAlMenu()
    {
        SceneManager.LoadScene(nombreEscenaMenu);
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