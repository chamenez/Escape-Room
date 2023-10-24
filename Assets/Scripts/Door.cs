using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true && Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("OpenDoor");
            isOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("CloseDoor");
    }
}
