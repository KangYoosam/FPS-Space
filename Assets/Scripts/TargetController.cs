using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
	[SerializeField] private int life;
	[SerializeField] private float wakeUpTime;
	[SerializeField] private Animator animator;
	private int attackedCount;

	public void Attacked ()
	{
		attackedCount++;

		if (life == attackedCount) {
			animator.SetBool ("broken", true);
			attackedCount = 0;
			Invoke ("WakeUp", wakeUpTime);
		}
	}

	private void WakeUp ()
	{
		animator.SetBool ("broken", false);
	}
}
