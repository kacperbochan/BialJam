using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyCoppier : MonoBehaviour
{
    public Camera outerCamera;
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.myCamera.transform.position = new Vector3(outerCamera.transform.position.x, outerCamera.transform.position.y, outerCamera.transform.position.z);
        this.myCamera.transform.rotation = new Quaternion(outerCamera.transform.rotation.x, outerCamera.transform.rotation.y, outerCamera.transform.rotation.z, outerCamera.transform.rotation.w);
    }
}
