using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rocketRotation = 1f;
    [SerializeField] AudioClip thrust;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThurst();
        ProcessRotate();
    }

    void ProcessThurst()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrust);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rocketRotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rocketRotation);
        }
        
    }

    void ApplyRotation(float thisRocketRotate)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * thisRocketRotate * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
