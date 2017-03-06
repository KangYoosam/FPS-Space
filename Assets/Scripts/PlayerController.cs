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
	}

	private void RayCast ()
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (Input.GetMouseButton (0) && gun.hasAny ()) {
				gun.Shot (hit.point);
//				gun.UseBullet ();
//				TargetController target = hit.collider.gameObject.GetComponent<TargetController> ();
//				if (target != null) {
//					target.Hit ();
//					score.CalcScore (hit.point);
//				}
			}
		}
	}
}
