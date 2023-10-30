using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform KeyResetPoint;
    private Transform player;

    public float pickUpDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPickedUp;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
        KeyResetPoint = GameObject.Find("KeyResetPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && itemIsPickedUp == true && readyToThrow)
        {
            //forceMulti = Math.Min(20, forceMulti + 300 * Time.deltaTime);
            forceMulti += 200 * Time.deltaTime;
        }

        pickUpDistance = Vector3.Distance(player.position, transform.position);

        // if the key somehow falls through the box collider, this will snap
        // it back to the starting point
        if (pickUpDistance > 200 && itemIsPickedUp == false)
        {
            this.transform.position = KeyResetPoint.position;
        }

        if (pickUpDistance <= 2)
        {
            if(Input.GetKeyDown(KeyCode.E) && itemIsPickedUp == false && PickUpPoint.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = PickUpPoint.position;
                this.transform.parent = GameObject.Find("PickUpPoint").transform;
                itemIsPickedUp = true;
                forceMulti = 0;
            }
        }

        if(Input.GetKeyUp(KeyCode.E) && itemIsPickedUp == true)
        {
            readyToThrow = true;
            if (forceMulti > 10)
            {
                rb.AddForce(player.transform.forward * forceMulti);
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                itemIsPickedUp = false;
                forceMulti = 0;
                readyToThrow = false;
            }

            forceMulti = 0;
        }
    }
}
