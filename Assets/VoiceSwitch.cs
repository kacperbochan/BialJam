using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject illegal;
    public GameObject border;
 
    public bool original = true;
    public float Radius = 20f;
    public bool isAdded = false;

    void Start()
    {
        border.SetActive(false);
        illegal.SetActive(true);
    }
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        
        if (dist < Radius)
        {
            if (!isAdded)
            {
                isAdded = true;
                GameObject go = GameObject.Find("EventSystem");
                MicrophoneInput cs = go.GetComponent<MicrophoneInput>();
                cs.AddToSwitch(this);

            }
        }
        else
        {
            if (isAdded) {
                isAdded = false;
                GameObject go = GameObject.Find("EventSystem");
                MicrophoneInput cs = go.GetComponent<MicrophoneInput>();
                cs.RemoveToSwitch(this);

            }
        }
    }

    public void SwitchThis()
    {
        original = !original;
        if (illegal != null) illegal.SetActive(!illegal.active);
        if (border != null) border.SetActive(!border.active);
    }
}
