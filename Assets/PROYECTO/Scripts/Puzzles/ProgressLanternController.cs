using UnityEngine;

public class ProgressLanternController : MonoBehaviour
{
    [Header("Las flamas en el orden que se encenderán")]
    public MeshRenderer[] flameRenderers; 

    [Header("El nuevo material de la flama (puzzle resuelto)")]
    public Material solvedFlameMaterial;
    private int currentLanternIndex = 0;
    public void LightNextLantern()
    {
        if (currentLanternIndex < flameRenderers.Length)
        {
            if (flameRenderers[currentLanternIndex] != null)
            {
                flameRenderers[currentLanternIndex].material = solvedFlameMaterial;
            }
            
            Debug.Log($"Progreso: Lámpara {currentLanternIndex + 1} de {flameRenderers.Length} encendida.");
            currentLanternIndex++;
        }
        else
        {
            Debug.LogWarning("Se resolvió un puzzle, pero ya no hay más lámparas para encender.");
        }
    }
}