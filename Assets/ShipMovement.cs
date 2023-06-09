using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float moveX = Input.GetAxis("Vertical");

        if (moveX != 0)
        {

            Debug.Log("aa");
            rigidBody.AddForce(new Vector3(7*moveX, 0, 0), ForceMode.Acceleration);
        }
        }

}
