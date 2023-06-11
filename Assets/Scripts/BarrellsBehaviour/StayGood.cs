using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayGood : MonoBehaviour
{
	public GameObject judge;
	// Start is called before the first frame update
	void OnTriggerStay(Collider other)
	{
		judge.GetComponent<OverallBarellReaction>().Pass();
	}
}
