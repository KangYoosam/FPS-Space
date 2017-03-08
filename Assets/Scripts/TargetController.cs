using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
	[SerializeField] private int life;
	private Animator animator;
	private int attackedCount;

	private void Start ()
	{
		animator = this.GetComponent<Animator> ();
	}

	public void attacked ()
	{
		attackedCount++;

		if (life == attackedCount) {
			animator.SetBool ();
		}
	}
}
