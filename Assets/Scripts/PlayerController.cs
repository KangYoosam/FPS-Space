﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GunController gun;
	[SerializeField] private UIManager uiManager;
	private bool isSniper;

	private void Start ()
	{
		this.isSniper = false;
		uiManager.toggleSniperImage (this.isSniper);
	}

	// Update is called once per frame
	private void Update ()
	{
		RayCast ();

		if (Input.GetKeyDown (KeyCode.R) && gun.canReload ()) {
			gun.Reload ();
		}

		if (Input.GetMouseButton (1)) {
			this.SwitchBetweenSniperMode ();
		}
	}

	private void RayCast ()
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButton (0) && gun.canShot ()) {
				gun.Shot (hit);
			}
		}
	}

	private void SwitchBetweenSniperMode ()
	{
		this.isSniper = !this.isSniper;
		uiManager.toggleSniperImage (this.isSniper);
	}
}