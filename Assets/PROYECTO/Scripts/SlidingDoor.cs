using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool IsOpen => isOpen; // Corregido el error de dedo "IsOpoen"
    private bool isOpen = false;

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        anim.SetBool("isOpen", isOpen);
    }

    public void OpenDoor()
    {
        isOpen = true;
        anim.SetBool("isOpen", isOpen);
    }

    public void CloseDoor()
    {
        isOpen = false;
        anim.SetBool("isOpen", isOpen);
    }
}