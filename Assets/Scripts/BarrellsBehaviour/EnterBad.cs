using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBad : MonoBehaviour
{
	public GameObject judge;
	void OnTriggerEnter(Collider other)
	{
		judge.GetComponent<OverallBarellReaction>().Wrong();
	}
}