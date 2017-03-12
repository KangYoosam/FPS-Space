﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Text timer;
	[SerializeField] private Text point;
	[SerializeField] private Text bullet;
	[SerializeField] private Text magazine;
	[SerializeField] private GunController gunController;
	[SerializeField] private GameManager gameManager;
	private float time;

	// Update is called once per frame
	void Update ()
	{
		timer.text = "Time : " + (90f - Time.time).ToString ("N1") + "s";
		point.text = "Pt : " + gameManager.GetCurrentPoint ();
		bullet.text = "Bullet : " + gunController.loadedBulletCount + "/" + gunController.loadableBulletCount;
		magazine.text = "BulletBox : " + gunController.magazineCount;
	}
}
