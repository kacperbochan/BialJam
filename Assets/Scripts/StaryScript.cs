using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaryScript : MonoBehaviour
{
    public GameObject stary;
    public ShipMovement ship;

    // Update is called once per frame
    void Update()
    {
        this.stary.transform.position += new Vector3(0.005f, 0, 0);
    }
}
