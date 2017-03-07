﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] public int loadableBulletCount;
	[SerializeField] public int magazineCount;
	public int loadedBulletCount;

	[SerializeField] private GameObject muzzle;
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private GameObject MuzzlefireParticle;
	[SerializeField] private AudioClip shotSound;
	[SerializeField] private AudioClip reloadSound;
	[SerializeField] private float coolTime;

	private AudioSource audioSource;
	private bool isEmpty;
	private bool isChilling;

	// Use this for initialization
	private void Start ()
	{
		isEmpty = false;
		isChilling = false;
		audioSource = this.GetComponent<AudioSource> ();
		loadedBulletCount = loadableBulletCount; // 装弾可能な段数を格納
	}

	public void Reload ()
	{
		if (canReload ()) {
			int consumedBulletCount = loadableBulletCount - loadedBulletCount;

			if (consumedBulletCount <= magazineCount) {
				magazineCount -= consumedBulletCount;
				loadedBulletCount += consumedBulletCount;
			} else {
				magazineCount = 0;
				loadedBulletCount += magazineCount;
			}

			audioSource.PlayOneShot (reloadSound);
		}
	}

	private bool canReload ()
	{
		return loadedBulletCount < loadableBulletCount && magazineCount > 0;
	}

	public void Shot (Vector3 hitPoint)
	{
		Fire (hitPoint);
		isChilling = true;
		ConsumeBullet ();
		StartCoroutine ("CountCoolTime");
	}

	public bool canShot ()
	{
		return !isEmpty && !isChilling;
	}

	IEnumerator CountCoolTime ()
	{
		yield return new WaitForSeconds (coolTime);

		isChilling = false;
	}

	private void Fire (Vector3 hitPoint)
	{
		GameObject muzzleFire = Instantiate (MuzzlefireParticle, muzzle.transform.position, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);
		GameObject fire = Instantiate (fireParticle, hitPoint, Quaternion.identity);

		Destroy (muzzleFire, 0.3f);
		Destroy (fire, 0.5f);
	}

	private void ConsumeBullet ()
	{
		loadedBulletCount--;

		if (loadedBulletCount == 0) {
			isEmpty = true;
		}
	}
}