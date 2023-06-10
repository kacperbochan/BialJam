using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public bool right=true;
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount=1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    public float offset ;
    public float heightOffset;
    public GameObject parent;
    public Transform startTransform;

    private void Start()
    {
        parent = transform.parent.gameObject;
        startTransform = transform;
    }

    private void FixedUpdate()
    {
        float shipRotation = parent.GetComponent<ShipMovement>().rotationForce;
        if(right)
        {
            if(shipRotation> 0) 
            {
                displacementAmount= 1-shipRotation*0.7f;
            }else
            {
                displacementAmount = 1f;
            }
        }
        else
        {
            if(shipRotation < 0)
            {
                displacementAmount = 1 + shipRotation * 0.7f;
            }else
            {
                displacementAmount = 1f;
            }
        }
        rigidbody.AddForceAtPosition(Physics.gravity/floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x + offset + parent.transform.position.x);
        if (transform.position.y < waveHeight)
        { 
            float displacementMultiplier = Mathf.Clamp01((waveHeight-transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),transform.position, ForceMode.Acceleration);
            rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }
    }

}
