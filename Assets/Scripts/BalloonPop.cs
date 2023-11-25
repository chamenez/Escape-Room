using UnityEngine;

public class BalloonPopScript : MonoBehaviour
{
    public AnimationClip balloonPopAnimation;
    public GameObject basketToDrop;

    private bool hasPopped = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasPopped && collision.gameObject.CompareTag("ThrowingKnife"))
        {
            // Play the balloon pop animation
            GetComponent<Animation>().Play(balloonPopAnimation.name);

            // Disable the collider so that the balloon won't pop again
            GetComponent<Collider>().enabled = false;

            // Enable gravity on the basket to make it fall
            Rigidbody basketRigidbody = basketToDrop.GetComponent<Rigidbody>();
            if (basketRigidbody != null)
            {
                basketRigidbody.isKinematic = false;
            }

            // Set the flag to prevent multiple pops
            hasPopped = true;

            // Destroy the balloon after a delay (adjust the delay as needed)
            Destroy(gameObject, balloonPopAnimation.length);
        }
    }
}

