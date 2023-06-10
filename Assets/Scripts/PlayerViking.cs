using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViking : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIddle()
    {
        animator.SetBool("InputRight", false);
		animator.SetBool("InputLeft", false);
	}

    public void PlayAnimRight()
    {
		animator.SetBool("InputRight", true);
		animator.SetBool("InputLeft", false);
	}

	public void PlayAnimLeft()
	{
		animator.SetBool("InputRight", false);
		animator.SetBool("InputLeft", true);

	}
}
