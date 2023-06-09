using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(ChangeSceneWithDelay());
	}

	// Update is called once per frame
	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
	void Start()
	{
		//Start the coroutine we define below named ExampleCoroutine.
	}

	IEnumerator ChangeSceneWithDelay()
	{
		//Print the time of when the function is first called.
		Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);

		// changed scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		//After we have waited 5 seconds print the time again.
		Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}
}

