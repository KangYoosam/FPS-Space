using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Text bullet;
	[SerializeField] private Text magazine;
	[SerializeField] private GunController gunController;

	// Update is called once per frame
	void Update ()
	{
		bullet.text = "Bullet : " + gunController.loadedBulletCount + "/" + gunController.loadableBulletCount;
		magazine.text = "BulletBox : " + gunController.magazineCount;
	}
}
