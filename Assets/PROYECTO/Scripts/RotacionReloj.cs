using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotacionReloj : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Transform manoTransform;
    private GameObject referenciaManual;

    [Header("Configuración del Acertijo")]
    public float anguloCorrecto = 0f; 
    public float tolerancia = 20f; 
    public bool resuelto = false; 

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        if (grab != null)
        {
            grab.selectEntered.AddListener(AlAgarrar);
            grab.selectExited.AddListener(AlSoltar);
        }
    }

    private void AlAgarrar(SelectEnterEventArgs args)
    {
        #if UNITY_2021_3_OR_NEWER
            if (args.interactorObject != null) manoTransform = args.interactorObject.transform;
        #else
            if (args.interactor != null) manoTransform = args.interactor.transform;
        #endif

        if (referenciaManual == null)
        {
            referenciaManual = new GameObject("Ref_" + name);
            referenciaManual.transform.position = transform.position;
            referenciaManual.transform.rotation = transform.rotation;
        }
    }

    private void AlSoltar(SelectExitEventArgs args) => manoTransform = null;

    void Update()
    {
        if (manoTransform != null && referenciaManual != null)
        {
            Vector3 direccionMano = manoTransform.position - transform.position;
            Vector3 localDireccion = referenciaManual.transform.InverseTransformDirection(direccionMano);
            float angulo = Mathf.Atan2(localDireccion.y, localDireccion.z) * Mathf.Rad2Deg;

            transform.localRotation = referenciaManual.transform.localRotation * Quaternion.Euler(angulo, 0, 0);
        }

        float anguloActual = transform.localEulerAngles.x;
        float diferencia = Mathf.Abs(Mathf.DeltaAngle(anguloActual, anguloCorrecto));
        resuelto = (diferencia <= tolerancia);
    }
}