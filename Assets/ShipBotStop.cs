using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBotStop : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Rigidbody rigidBody;
    public float maxSpeed = 20;
    public int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(waypoints[waypointIndex].transform);
        transform.Rotate(0, -90, 0);
        float piDeegre = transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        rigidBody.AddForce(new Vector3(Mathf.Cos(piDeegre) * maxSpeed, 0, -Mathf.Sin(piDeegre) * maxSpeed), ForceMode.Force);
        if ((transform.position - waypoints[waypointIndex].transform.position).magnitude < 5)
        {
            if (waypointIndex != (waypoints.Count - 1))
                waypointIndex++;
            else
            {
                waypointIndex = 0;
                transform.position = waypoints[waypointIndex].transform.position;

            }
        }
    }
}
