using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample : MonoBehaviour
{
	public void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		Application.Quit();
	}
}