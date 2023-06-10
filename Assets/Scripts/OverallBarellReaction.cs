using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallBarellReaction : MonoBehaviour
{
	public GameObject canvas;
	public bool passed = false;

	//event zostaje "wyl¹czony"
	public void Pass()
	{
		passed = true;
	}

	//event
	void OnTriggerEnter(Collider other)
	{
		//Wrong();
		//pass
	}

	//usun tarcze
	public void Wrong()
	{
		if (!passed)
		{
			Pass();
			canvas.GetComponent<Tarcze>().destroyShield();
		}
	}
}
