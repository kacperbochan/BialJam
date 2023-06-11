using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stary : MonoBehaviour
{
    public float velocity = 1;
        // Update is called once per frame
    void FixedUpdate()
    {
		transform.Translate(Vector3.right * velocity* Time.deltaTime);
	}
}
