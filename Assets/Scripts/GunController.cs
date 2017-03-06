using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private AudioClip shotSound;

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
		GameObject fire = Instantiate (fireParticle, hitPoint, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);

		Destroy (fire, 0.5f);
	}

	public bool hasAny ()
	{
		return !isEmpty;
	}
}