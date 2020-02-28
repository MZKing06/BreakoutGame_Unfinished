using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float ballInitialVelocity = 750f;

    Rigidbody rb;
    bool ballInPlay;
    public AudioSource ballHit;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballHit.Play();
    }
}
