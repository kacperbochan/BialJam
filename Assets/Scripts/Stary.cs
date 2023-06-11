using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stary : MonoBehaviour
{
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
    }
    void FixedUpdate()
    {
        Transform follow;

		if(waypointIndex==waypoints.Count)
        {
            follow= ship.transform;
        }else
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
        GameObject wayPoint= GameObject.CreatePrimitive(PrimitiveType.Cube);
        wayPoint.transform.position = ship.transform.position;
        wayPoint.GetComponent<BoxCollider>().enabled = false;
        waypoints.Add(wayPoint.transform);
    }
}
