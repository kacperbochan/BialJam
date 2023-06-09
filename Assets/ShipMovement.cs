using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float offset = 0;
    public Vector2 windDirection = new Vector2(0, 0);
    public float windForce = 0;
    public float speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float piDeegre = transform.rotation.eulerAngles.y / 180 * Mathf.PI;
        float moveX = Input.GetAxis("Vertical");
        rigidBody.AddForce(new Vector3(windDirection.x * windForce, windDirection.y * windForce, 0), ForceMode.Acceleration);
        if (moveX != 0)
        {
            rigidBody.AddForce(new Vector3(Mathf.Cos(piDeegre)*speed*moveX, 0, -Mathf.Sin(piDeegre) * speed * moveX), ForceMode.Acceleration);

        }
        }

}
