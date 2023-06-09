using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentSegment = 1;

    public List<GameObject> allSegments = new List<GameObject>();
    public List<GameObject> currentSegments = new List<GameObject>();

    public void UpdateSegment()
    {
        GameObject newSegment = Instantiate(allSegments[Random.Range(0, allSegments.Count)]);
        currentSegments.Add(newSegment);
        currentSegments.RemoveAt(0);
    }


}
