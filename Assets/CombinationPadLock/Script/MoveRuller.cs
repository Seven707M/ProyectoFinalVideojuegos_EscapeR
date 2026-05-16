using System.Collections.Generic;
using UnityEngine;

public class MoveRuller : MonoBehaviour
{
    private PadLockPassword _lockPassword;

    public List<GameObject> _rullers = new List<GameObject>();
    
    public int[] _numberArray = { 0, 0, 0, 0 };

    private int _changeRuller = 0;
    private int _scroolRuller = 36;

    void Awake()
    {
        _lockPassword = FindObjectOfType<PadLockPassword>();

        _rullers.Add(GameObject.Find("Ruller1"));
        _rullers.Add(GameObject.Find("Ruller2"));
        _rullers.Add(GameObject.Find("Ruller3"));
        _rullers.Add(GameObject.Find("Ruller4"));

        foreach (GameObject r in _rullers)
        {
            r.transform.Rotate(-144, 0, 0, Space.Self);
        }
    }

    public void VR_SeleccionarRodillo(int indiceRodillo)
    {
        _changeRuller = indiceRodillo;

        for (int i = 0; i < _rullers.Count; i++)
        {
            PadLockEmissionColor emissionScript = _rullers[i].GetComponent<PadLockEmissionColor>();
            if (emissionScript != null)
            {
                emissionScript._isSelect = (_changeRuller == i);
                emissionScript.BlinkingMaterial();
            }
        }
    }

    public void VR_GirarRodilloAdelante()
    {
        if (_rullers.Count == 0) return;

        _numberArray[_changeRuller] += 1;
        if (_numberArray[_changeRuller] > 9)
        {
            _numberArray[_changeRuller] = 0;
        }

        Debug.Log("Rodillo " + _changeRuller + " cambio al valor: " + _numberArray[_changeRuller]);

        _rullers[_changeRuller].transform.Rotate(-_scroolRuller, 0, 0, Space.Self);

        if (_lockPassword != null)
        {
            _lockPassword.Password();
        }
    }
}