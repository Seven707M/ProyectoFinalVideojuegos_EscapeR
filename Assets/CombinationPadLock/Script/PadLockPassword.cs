// Script optimizado y con rastreo de errores para VR
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PadLockPassword : MonoBehaviour
{
    private MoveRuller _moveRull;
    public GameObject imagess;
    public int[] _numberPassword = { 0, 0, 0, 0 }; 
    public DoorController targetDoor;
    [Header("Evento al ganar")]
    public UnityEvent onGameSolved;

    private void Start()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
        
        if (_moveRull == null)
        {
            Debug.LogError("¡ERROR! No se encontró el script MoveRuller en la escena.");
        }
    }

    public void Password()
    {
        if (_moveRull == null) return;

        string actual = string.Join(",", _moveRull._numberArray);
        string esperada = string.Join(",", _numberPassword);
        Debug.Log("Combinación actual: [" + actual + "] | Combinación esperada: [" + esperada + "]");

        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
        {
            Debug.Log("El candado se ha abierto");

            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                PadLockEmissionColor emission = _moveRull._rullers[i].GetComponent<PadLockEmissionColor>();
                if (emission != null)
                {
                    emission._isSelect = false;
                    emission.BlinkingMaterial(); 
                }
            }
            Destroy(gameObject);
            Destroy(imagess);
            targetDoor.OpenDoor();
            onGameSolved.Invoke();
        }
    }
}