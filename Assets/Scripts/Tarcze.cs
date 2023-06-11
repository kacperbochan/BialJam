using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarcze : MonoBehaviour
{
    public ShipMovement ship;
    public Thunder thunder;
    public int shieldLimit = 5;
    public int shieldCount = 3;
    public GameObject shieldPrefab;
    public GameObject[] clone;
    public int offset = 0;

    void Start()
    {
        clone = new GameObject[shieldLimit];
        for(int i = 0; i < shieldCount; i++)
        {
            addShield(i);
		}
    }

    public void addShield(int i)
	{
		GameObject shield = Instantiate(shieldPrefab, transform);
		shield.transform.position = new Vector3(50 + offset, 50, 0);
		offset += 80;
		clone[i] = shield;
	}

    public void destroyShield()
    {
        shieldCount--;

        if(shieldCount > 0)
        {
            Destroy(clone[shieldCount]);
        }
        else
        {
            ship.enabled= false;
            ship.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-40, 40), 40, Random.Range(-40, 40), ForceMode.Impulse);
            ship.gameObject.GetComponent<Rigidbody>().AddTorque(Random.Range(-100, 100), 0, 0, ForceMode.Impulse);
            ship.gameObject.GetComponent<Rigidbody>().useGravity = true;
            thunder.spawn();
            Destroy(clone[shieldCount]);
           
        }
    }


}
