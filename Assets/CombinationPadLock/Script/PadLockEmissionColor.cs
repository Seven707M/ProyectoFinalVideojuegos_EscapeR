using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    TimeBlinking tb;
    private GameObject _myRuller;

    public bool _isSelect;

    private void Awake()
    {
        tb = FindObjectOfType<TimeBlinking>();
    }

    void Start()
    {
        _myRuller = gameObject;
        _myRuller.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if (_isSelect && tb != null)
        {
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.clear, Color.yellow, Mathf.PingPong(Time.time, tb.blinkingTime)));
        }
    }

    public void BlinkingMaterial()
    {
        if (!_isSelect)
        {
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }
    }
}