using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    [SerializeField] ObjectPool objectPool;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        GameObject projectile = objectPool.GetObjectFromPool();
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        projectile.SetActive(true);
    }
}
