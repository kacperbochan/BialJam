using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fatherChaseAudio : MonoBehaviour
{
    public GameObject father;
    public GameObject son;
    public AudioSource source;
    public AudioClip close;
    public AudioClip mid;
    public AudioClip far;
    public AudioClip win;
    public bool active = true;
    public int cur=0;
    void Start()
    {
        source= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            float distance = (father.transform.position - son.transform.position).magnitude;


            if (distance < 20)
            {
                if (cur != 1)
                {
                    source.clip = close;
                    source.Play();
                    cur = 1;
                }

            }
            else
            if (distance < 30)
            {
                if (cur != 2)
                {
                    source.clip = mid;
                    source.Play();
                    cur = 2;
                }
            }
            else
            if (distance < 50)
            {
                if (cur != 3)
                {
                    source.clip = far;
                    source.Play();
                    cur = 3;
                }
            }

        }
    }
    public void Win()
    {
        active= false;
        source.clip = win;
        source.Play();
    }
}
