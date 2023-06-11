using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public GameObject thunderOrigin;
    public AudioSource audioSource;
    public ParticleSystem ps;

	private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            spawn();
    }

	public void spawn()
    {
        GameObject thunder = Instantiate(thunderOrigin, transform);
        audioSource.Play();
        ps.Play();
        Destroy(thunder, 0.1f);
    }
}
