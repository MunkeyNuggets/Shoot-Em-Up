using UnityEngine;
using System.Collections;

public class Missile : Projectile {

	GameManager gameManager;

	public float rotationSpeed = 10.0f;

	private GameObject closestTarget;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, lifeTime);

		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}


	public override void Movement(){

		transform.position += transform.forward * moveSpeed * Time.deltaTime;

		//Find closest enemy target
		if (closestTarget == null)
			closestTarget = FindClosestTarget ();

		//Missile Guidance - target lock
		if (closestTarget != null) {
			//Smooth lock
			//Determine the target rotation
			Quaternion targetRotation = Quaternion.LookRotation(closestTarget.transform.position - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		}
	}



	public GameObject FindClosestTarget(){

		GameObject target = null;

		float distance = Mathf.Infinity;

		if (gameManager.enemies.Length > 0) {
			foreach (GameObject enemy in gameManager.enemies) {

				Vector3 diff = enemy.transform.position - transform.position;
				float curDistance = diff.sqrMagnitude;

				if (curDistance < distance) {
					target = enemy;
					distance = curDistance;
				}
			}
		}
		return target;
	}


}
