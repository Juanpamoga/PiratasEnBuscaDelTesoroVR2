using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoorLever : MonoBehaviour
{
    public bool isAlreadyOpen = false;
    public Animator animator;
    public void OpenDoor()
    {
        if (isAlreadyOpen) return;
        isAlreadyOpen = true;
        SoundManager.Instance.PlaySound("Door");
        animator.Play("OpenDoor");
    }
}
