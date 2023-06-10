using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarcze : MonoBehaviour
{
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
		shield.transform.position = new Vector3(0 + offset, 0, 0);
		offset += 60;
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
            //gameover
        }
    }


}
