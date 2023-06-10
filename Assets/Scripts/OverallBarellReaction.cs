using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallBarellReaction : MonoBehaviour
{
	public GameObject canvas;
	public bool passed = false;

	public void Pass()
	{
		passed = true;
	}

	void OnTriggerEnter(Collider other)
	{
		Wrong();
	}

	public void Wrong()
	{
		if (!passed)
		{
			Pass();
			canvas.GetComponent<Tarcze>().destroyShield();
		}
	}
}
