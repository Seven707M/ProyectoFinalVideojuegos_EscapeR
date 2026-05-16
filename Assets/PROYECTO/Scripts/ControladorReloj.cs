using UnityEngine;
using UnityEngine.Events;

public class ControladorReloj : MonoBehaviour
{
    public RotacionReloj manecillaHoras;
    public RotacionReloj manecillaMinutos;
    public UnityEvent OnAcertijoResuelto; 
    private bool yaSeGano = false;
    //Para las notas
    public GameObject nota3;
    public AudioClip sonidoNota;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (yaSeGano) return;

        if (manecillaHoras != null && manecillaMinutos != null)
        {
            if (manecillaHoras.resuelto && manecillaMinutos.resuelto)
            {
                yaSeGano = true;
                Debug.Log("<color=green><b>¡ACERTIJO RESUELTO!</b></color>");
                OnAcertijoResuelto.Invoke();
                //Nota
                nota3.SetActive(true);
                audioSource.PlayOneShot(sonidoNota);
            }
        }
    }
}