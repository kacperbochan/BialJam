using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipAudioResponse: MonoBehaviour
{
	public AudioSource audioSource;

    public Tarcze shields;
    public AudioClip iceCrack;
    public AudioClip sandCrack;
    public AudioClip woodCrack;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        GetComponent<ShipMovement>().maxSpeed = GetComponent<ShipMovement>().maxSpeed -20 ;
        if (collision.gameObject.layer == 0)
        {
            audioSource.clip= iceCrack;
            audioSource.Play();
        }
		if (collision.gameObject.layer == 3)
		{
            shields.destroyShield();
            collision.gameObject.layer = 1;
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
