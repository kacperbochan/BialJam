using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    public Stary father;
    public ShipMovement ship;
    public fatherChaseAudio FatherChaseAudio;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 7)
        {

            FatherChaseAudio.Win();
            Destroy(this);
        }
    }
}
