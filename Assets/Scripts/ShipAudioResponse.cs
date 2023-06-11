using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipAudioResponse: MonoBehaviour
{
    public AudioSource iceCrack;
	public AudioSource woodCrack;
	public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Default")
        {
            iceCrack.Play();
        }
		if (collision.gameObject.tag == "Wood")
		{
			woodCrack.Play();
		}
	}
}
