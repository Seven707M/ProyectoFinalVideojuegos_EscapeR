using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BotellasControlador : MonoBehaviour
{
    void Start()
{
    foreach (var socket in sockets)
    {
        socket.onSelectEntered.AddListener((args) => VerificarOrden());
    }
}
    [Header("Sockets donde se colocan las botellas")]
    public List<XRSocketInteractor> sockets;

    [Header("Orden correcto por TAGS")]
    public List<string> ordenCorrectoTags;

    public void VerificarOrden()
    {
        int aciertos = 0;

        for (int i = 0; i < sockets.Count; i++)
        {
            XRBaseInteractable interactuable = sockets[i].selectTarget;

            if (interactuable != null)
            {
                if (interactuable.transform.CompareTag(ordenCorrectoTags[i]))
                {
                    aciertos++;
                }
            }
        }

        if (aciertos == sockets.Count)
        {
            Debug.Log("Orden correcto detectado ✅");
        }
        else
        {
            Debug.Log("Orden incorrecto ❌");
        }
    }
}