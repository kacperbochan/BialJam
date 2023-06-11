using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipAudioResponse: MonoBehaviour
{
	public AudioSource audioSource;


    public AudioClip iceCrack;
    public AudioClip sandCrack;
    public AudioClip woodCrack;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 0)
        {
            audioSource.clip= iceCrack;
            audioSource.Play();
        }
		if (collision.gameObject.layer == 3)
		{

            audioSource.clip = woodCrack;
            audioSource.Play();
        }
        if (collision.gameObject.layer == 6)
        {

            audioSource.clip = sandCrack;
            audioSource.Play();
        }
    }
}
