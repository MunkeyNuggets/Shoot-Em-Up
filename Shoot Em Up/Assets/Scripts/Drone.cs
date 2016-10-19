using UnityEngine;
using System.Collections;

public class Drone : Enemy {

	//Movement variables
	public float moveSpeed = 5.0f;
	public float rotationSpeed = 2.0f;
	private float adjRotSpeed;
	private Quaternion targetRotation;

	// Update is called once per frame
	void Update () {
		Movement ();
	}


	private void Movement(){
		//Rotating towards the player based on LOS
		if (player.transform.position.z <= transform.position.z) {
			targetRotation = Quaternion.LookRotation (player.transform.position - transform.position);
			adjRotSpeed = Mathf.Min (rotationSpeed * Time.deltaTime, 1);
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, adjRotSpeed);
		}

		transform.position += transform.forward * moveSpeed * Time.deltaTime;

		//Enemy positional check vs boundary
		if (transform.position.z <= gameManager.zBoundary - 100)
			Destroy (this.gameObject);

	}
}
