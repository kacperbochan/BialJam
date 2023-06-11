using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{

    public GameObject thunderOrigin;
    public AudioSource audioSource;
    public ParticleSystem ps;

	public void spawn()
    {
        GameObject thunder = Instantiate(thunderOrigin, transform);

        audioSource.volume = 1f;
        audioSource.reverbZoneMix = 0f;
        audioSource.Play();
        ps.Play();
        Destroy(thunder, 0.1f);
    }
    public void sound()
    {
        audioSource.Play();
        audioSource.volume = 0.3f;
        audioSource.reverbZoneMix = 0.8f;
    }
}
