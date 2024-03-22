using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBounce : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
            audioSource.Play();
    }
}
