using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GunController gun;

	// Update is called once per frame
	private void Update ()
	{
		RayCast ();

//		if (Input.GetKeyDown (KeyCode.R)) {
//			gun.Reload ();
//		}
	}

	private void RayCast ()
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButton (0) && gun.canShot ()) {
				gun.Shot (hit.point);
			}
		}
	}
}