using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private AudioClip shotSound;
	[SerializeField] public int bullet_count;

	private AudioSource audioSource;
	private bool isEmpty;

	// Use this for initialization
	private void Start ()
	{
		isEmpty = false;
		audioSource = this.GetComponent<AudioSource> ();
	}

	public void Shot (Vector3 hitPoint)
	{
		Fire (hitPoint);
		ConsumeBullet ();
	}

	public bool hasAny ()
	{
		return !isEmpty;
	}

	private void Fire (Vector3 hitPoint)
	{
		GameObject fire = Instantiate (fireParticle, hitPoint, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);

		Destroy (fire, 0.5f);
	}

	private void ConsumeBullet ()
	{
		bullet_count--;

		if (bullet_count == 0) {
			isEmpty = true;
		
		} else if (bullet_count < 0) {
			Debug.Log ("弾数がマイナスになっています");
		}
	}
}