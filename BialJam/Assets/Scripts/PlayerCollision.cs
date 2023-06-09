using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if(collision.collider.tag == "Obstacle")        
            movement.enabled = false;

    }
}
