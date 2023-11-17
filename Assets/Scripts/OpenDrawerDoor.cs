using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool doorOpened;
    private bool coroutineAllowed;
    private Transform player;
    public float interactDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        doorOpened = false;
        coroutineAllowed = true;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (coroutineAllowed && Input.GetKeyDown(KeyCode.E) && distanceToPlayer <= interactDistance)
        {
            if (!doorOpened)
            {
                StartCoroutine("OpenThatDoor");
            }
            else
            {
                StartCoroutine("CloseThatDoor");
            }
        }
    }

    private IEnumerator OpenThatDoor()
    {
        coroutineAllowed = false;
        for (float i = 0f; i <= 45f; i += 3f)
        {
            transform.localRotation = Quaternion.Euler(0f, -i, 0f);
            yield return new WaitForSeconds(0f);
        }
        doorOpened = true;
        coroutineAllowed = true;
    }

    private IEnumerator CloseThatDoor()
    {
        coroutineAllowed = false;
        for (float i = 45f; i >= 0f; i -= 3f)
        {
            transform.localRotation = Quaternion.Euler(0f, -i, 0f);
            yield return new WaitForSeconds(0f);
        }
        doorOpened = false;
        coroutineAllowed = true;
    }
}
