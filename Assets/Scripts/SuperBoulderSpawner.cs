using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBoulderSpawner : MonoBehaviour
{
    public GameObject boulder;
    void Start()
    {
        InvokeRepeating("BoulderTime", 1f, 1f);  //1s delay, repeat every 1s
    }
    void BoulderTime()
    {
        GameObject tmp= Instantiate(
            boulder,transform.position+new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10))
            ,transform.rotation);
        float randScale = Random.Range(5, 30) / 10f;
        tmp.transform.localScale= new Vector3(randScale,randScale,randScale);
        tmp.SetActive(true);
        
    }
    private void FixedUpdate()
    {
          
    }
}
