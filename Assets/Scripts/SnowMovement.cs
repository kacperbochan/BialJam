using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMovement : MonoBehaviour
{
    public Transform ship;

    void Update()
    {
        transform.position = ship.position;
    }
}
