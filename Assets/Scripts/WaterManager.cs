using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    public float offset = 0;
    // Start is called before the first frame update
    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] verticies = meshFilter.mesh.vertices;
        for (int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = WaveManager.instance.GetWaveHeight(verticies[i].x + transform.position.x+offset);
        }
        meshFilter.mesh.vertices = verticies;
        meshFilter.mesh.RecalculateNormals();
    }
}
