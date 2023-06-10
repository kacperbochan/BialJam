using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float offset = 0;

    public float rotationForce = 0;

    //pasywny ruch ³odki
    public Vector2 windDirection = new Vector2(0, 0);
    public float windForce = 0;



    //aktywny ruch ³ódki
    public float roatationSpeed = 7;//maxymalna predkosc skretu
    public float maxSpeed = 10;

    public float velocity = 0;
    public float anchor = 0;
    public GameObject rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (velocity > 1)
            maxSpeed += 400 * Time.deltaTime / Mathf.Pow(maxSpeed, 1.1f);
        else
            maxSpeed = 10;


        float piDeegre = transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        float wheelRotation = Input.GetAxis("Horizontal");
        float anchorInput = Input.GetAxis("Anchor");

        rotationForce = wheelRotation;

        rigidBody.AddForce(new Vector3(windDirection.x * windForce, windDirection.y * windForce, 0), ForceMode.Acceleration);
        velocity=rigidBody.velocity.magnitude;


        rigidBody.AddForce(new Vector3(Mathf.Cos(piDeegre)*maxSpeed,0,-Mathf.Sin(piDeegre)*maxSpeed),ForceMode.Force);
        if (wheelRotation != 0)// skret zalezny 
        {
            maxSpeed = maxSpeed *(1-(Mathf.Abs(wheelRotation))/300);
            transform.RotateAround(rotationPoint.transform.position, Vector3.up, roatationSpeed*Time.deltaTime*wheelRotation *velocity);
        }
        

        }

}
