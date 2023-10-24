using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;

    private bool isOpen = false;
    private bool isClosed = true;

    private FPSController keys;

    // Start is called before the first frame update
    void Start()
    {
        keys = FindObjectOfType<FPSController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true && Input.GetKey(KeyCode.E) && keys.keyAmount >= 1)
        {
            //keys.keyAmount -= 1;
            anim.SetTrigger("OpenDoor");
            isOpen = false;
            isClosed = false;
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
        if (isClosed == false)
        {
            anim.SetTrigger("CloseDoor");
        }
    }
}
