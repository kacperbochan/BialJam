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

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < Radius)
        {
            if (!isAdded)
            {
                GameObject go = GameObject.Find("PlayerMicro");
                MicrophoneInput cs = go.GetComponent<MicrophoneInput>();
                cs.AddToSwitch(this);

            }
        }
    }

    public void SwitchThis()
    {
        isAdded = false;
        original = !original;
        if (illegal != null) illegal.SetActive(!illegal.active);
        if (border != null) border.SetActive(!border.active);
    }
}
