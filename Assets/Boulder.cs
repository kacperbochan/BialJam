using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject,10);
    }
}
