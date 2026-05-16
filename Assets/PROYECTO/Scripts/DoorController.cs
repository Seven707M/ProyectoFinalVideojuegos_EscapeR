using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool _shouldOpen = false;
    private Quaternion _targetRotation; 
    private AudioSource _audioSource;

    public float degreesToRotate = 90f; 
    public float openSpeed = 2f;    
    public AudioClip doorOpenSound;     

    void Start()
    {
        _targetRotation = transform.localRotation * Quaternion.Euler(0, degreesToRotate, 0);
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_shouldOpen)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _targetRotation, Time.deltaTime * openSpeed);
        }
    }

    public void OpenDoor()
    {
        if (_shouldOpen) return;
        _shouldOpen = true;
        Debug.Log("FELICIDADES");
        if (_audioSource != null && doorOpenSound != null)
        _audioSource.PlayOneShot(doorOpenSound);
    }
}