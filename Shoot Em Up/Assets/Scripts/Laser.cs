using UnityEngine;
using System.Collections;

public class Laser : Projectile {

	public override void Movement(){
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
