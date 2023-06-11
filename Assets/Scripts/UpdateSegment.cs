using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSegment : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.UpdateSegment();
    }
}
