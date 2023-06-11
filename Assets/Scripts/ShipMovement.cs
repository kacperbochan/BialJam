using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    public Transform steeringWheel;
    public Rigidbody rigidBody;

    MicrophoneInput cs;

    public float offset = 0;

    public float rotationForce = 0;

    //pasywny ruch �odki
    public Vector2 windDirection = new Vector2(0, 0);
    public float windForce = 0;



    //aktywny ruch ��dki
    public float roatationSpeed = 7;//maxymalna predkosc skretu
    public float maxSpeed = 10;

    public float velocity = 0;
    public float anchor = 0;
    public GameObject rotationPoint;

    public GameObject Viking;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("EventSystem");
        cs = go.GetComponent<MicrophoneInput>();

        rigidBody = GetComponent<Rigidbody>();
    }

    void setAnimation(float rotationForce)
    {
    	if (rotationForce > 0)
		{
			Viking.GetComponent<PlayerViking>().PlayAnimRight();
        }   
        if (rotationForce < 0)
        {
	        Viking.GetComponent<PlayerViking>().PlayAnimLeft();
        }
        if (rotationForce == 0)
        {
	        Viking.GetComponent<PlayerViking>().SetIddle();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (velocity > 1)
            maxSpeed += 550 * Time.deltaTime / Mathf.Pow(maxSpeed, 1.2f);
        else
            maxSpeed = 10;


        float piDeegre = transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        float wheelRotation = Input.GetAxis("Horizontal");
        float anchorInput = Input.GetAxis("Anchor");

        rotationForce = wheelRotation;

        setAnimation(rotationForce);

		rigidBody.AddForce(new Vector3(windDirection.x * windForce, windDirection.y * windForce, 0), ForceMode.Acceleration);
        velocity=rigidBody.velocity.magnitude;


        rigidBody.AddForce(new Vector3(Mathf.Cos(piDeegre) * maxSpeed, 0, -Mathf.Sin(piDeegre) * maxSpeed), ForceMode.Force);
        if (wheelRotation != 0)// skret zalezny 
        {
            maxSpeed = maxSpeed * (1 - (Mathf.Abs(wheelRotation)) / 700);

                transform.RotateAround(rotationPoint.transform.position, Vector3.up, roatationSpeed * Time.deltaTime * wheelRotation * (velocity+anchorInput*2));
            steeringWheel.transform.Rotate(Vector3.left, (roatationSpeed + anchorInput * 6) * Time.deltaTime * wheelRotation * 10);
        }
        if (anchorInput != 0)
        {
            if (maxSpeed > 0)
                maxSpeed = maxSpeed * (1 - (Mathf.Abs(anchorInput)) / 100) - 0.05f; 
            else
                maxSpeed = 1;
        }


        
        if (cs.isFaster)
            maxSpeed += 1;


    }

    public void SpeedUp (){
     maxSpeed += 1;
    }

}
