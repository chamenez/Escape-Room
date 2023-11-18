using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void OpenChest()
    {
        Debug.Log("opening chest!!!");
        animator.SetBool("Open", true);
    }
}
