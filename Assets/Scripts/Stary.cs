using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stary : MonoBehaviour
{
    public ShipMovement shipMovement;
    public GameObject ship;
    private Rigidbody rigidBody;
    public List<Transform> waypoints= new List<Transform>();
    public int waypointIndex = 0;
    public float velocity = 1;
    public float maxSpeed;
    // Update is called once per frame
    private void Start()
    {
        rigidBody= GetComponent<Rigidbody>();
        InvokeRepeating("RespTime", 1f, 1f);  //1s delay, repeat every 1s
        GameObject wayPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wayPoint.transform.position = ship.transform.position;
        wayPoint.GetComponent<BoxCollider>().enabled = false;
        wayPoint.GetComponent<MeshRenderer>().enabled = false;

        waypoints.Add(wayPoint.transform);
    }
    void FixedUpdate()
    {
        Transform follow;

		if(waypointIndex==waypoints.Count)
        {
            follow= ship.transform;
            if ((transform.position - follow.position).magnitude < 3)
            {
                print("smierc.mp3");
                ship.AddComponent<Rigidbody>();
                //ship.GetComponent<BoxCollider>().enabled=false;
                Rigidbody shipRB= ship.GetComponent<Rigidbody>();
                shipRB.AddForce(Random.Range(-40,40), 40, Random.Range(-40, 40),ForceMode.Impulse);
                shipRB.AddTorque(Random.Range(-100, 100), 0, 0, ForceMode.Impulse);
                shipMovement.enabled= false;
                this.enabled=false;
            }
        }
        else
        {
            follow = waypoints[waypointIndex];
            if ((transform.position - follow.position).magnitude < 5)
            {
                waypointIndex++;    
            }
        }
        transform.LookAt(follow);
        //transform.Rotate(0, -90, 0);
        float piDeegre = transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        rigidBody.AddForce(new Vector3(Mathf.Sin(piDeegre) * maxSpeed, 0, Mathf.Cos(piDeegre) * maxSpeed), ForceMode.Force);

    }
    void RespTime()
    {
        if ((ship.transform.position - waypoints[waypoints.Count - 1].transform.position).magnitude > 10)
        {
            GameObject wayPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wayPoint.transform.position = ship.transform.position;
            wayPoint.GetComponent<BoxCollider>().enabled = false;
            wayPoint.GetComponent<MeshRenderer>().enabled = false;
            waypoints.Add(wayPoint.transform);
        }
    }
}
