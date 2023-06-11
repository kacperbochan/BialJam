using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illegal : MonoBehaviour
{
    public Tarcze shields;
    public GameObject thunder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    { 
        if(collision.gameObject.layer==7)
        {
            
            thunder.GetComponent<Thunder>().sound();
            shields.destroyShield();
            Destroy(this);
        }
    }
}
