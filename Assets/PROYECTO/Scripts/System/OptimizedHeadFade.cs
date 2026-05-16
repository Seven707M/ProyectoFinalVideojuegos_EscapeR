using System.Collections;
using UnityEngine;
using TMPro;

public class OptimizedHeadFade : MonoBehaviour
{
    [Header("Efectos Visuales")]
    public MeshRenderer fadeQuadRenderer;
    public TextMeshProUGUI warningText;

    [Header("Teletransporte")]
    public Transform xrRig;
    public Transform safeSpot;
    
    [Header("Configuración de Tiempo")]
    public int allowedSeconds = 5;

    private Material fadeMaterial;
    private Color fadeColor;
    private Coroutine warningCoroutine;

    private void Start()
    {
        fadeMaterial = fadeQuadRenderer.material;
        fadeColor = fadeMaterial.color;
        
        fadeMaterial.SetInt("unity_GUIZTestMode", (int)UnityEngine.Rendering.CompareFunction.Always);
        warningText.fontMaterial.SetInt("_ZTestMode", (int)UnityEngine.Rendering.CompareFunction.Always);
        warningText.fontMaterial.renderQueue = fadeMaterial.renderQueue + 1;

        SetAlpha(0f); 
        warningText.text = ""; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            SetAlpha(1f);
            
            warningCoroutine = StartCoroutine(CountdownRoutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pared"))
        {
            SetAlpha(0f); 
            warningText.text = ""; 
            
            if (warningCoroutine != null)
            {
                StopCoroutine(warningCoroutine);
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        fadeColor.a = alpha;
        fadeMaterial.color = fadeColor;
    }

    private IEnumerator CountdownRoutine()
    {
        int timeLeft = allowedSeconds;

        while (timeLeft > 0)
        {
            warningText.text = $"¡FUERA DE LA ZONA DE JUEGO!\nRegresa a la habitación en {timeLeft}...";
            
            yield return new WaitForSeconds(1f); 
            
            timeLeft--; 
        }

        Debug.Log("Tiempo agotado. Castigando al jugador...");
        xrRig.position = safeSpot.position;
        
        SetAlpha(0f);
        warningText.text = "";
    }
}