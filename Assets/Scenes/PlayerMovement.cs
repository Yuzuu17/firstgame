using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ref to Rigidbody called "rb"
    public Rigidbody rb;

    /*
    public AudioSource audiosource;
    public AudioClip footstepSound;
    public float footstepInterval = 1f;
    bool isPlayingFootstep = false;

    private void Start()

    {
        audiosource = GetComponent<AudioSource>();
    } */

    // fixedupdate using it to mess with physics
    void FixedUpdate()
    {
     

        if (Input.GetKey("a"))
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, 800 * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, -800 * Time.deltaTime);
        }


    
        /*
        if (isMoving || !isPlayingFootstep)
        {
            StartCoroutine(PlayFootstepSound());
        }

        IEnumerator PlayFootstepSound()
        {
            isPlayingFootstep = true;
            audiosource.PlayOneShot(footstepSound);
            yield return new WaitForSeconds(footstepInterval);
            isPlayingFootstep = false; 
        } */
    }
}
