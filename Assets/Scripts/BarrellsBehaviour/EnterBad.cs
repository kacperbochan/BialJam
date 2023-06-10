using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBad : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		GetComponent<OverallBarellReaction>().Wrong();
	}
}