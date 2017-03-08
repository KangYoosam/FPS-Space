using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Vector2 marker;
	private int score;

	public void CalculateScoreUsing (Vector3 hitPosition)
	{
		float distanceFromCenter = Vector2.Distance ((Vector2)hitPosition, marker);
		score += GetScore (distanceFromCenter);
	}

	private int GetScore (float distanceFromCenter)
	{
		distanceFromCenter -= 184f;

		if (distanceFromCenter < 0.26f) {
			return 100;

		} else if (distanceFromCenter < 0.262f) {
			return 90;

		} else if (distanceFromCenter < 0.264f) {
			return 80;

		} else if (distanceFromCenter < 0.266f) {
			return 70;

		} else if (distanceFromCenter < 0.268f) {
			return 60;

		} else {
			return 50;
		}
	}
}