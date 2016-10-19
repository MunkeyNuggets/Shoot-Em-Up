using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameManager gameManager;

	private Transform myTransform;

	private Vector3 playerPosition;

	public float moveSpeed = 50.0f;

	public GameObject[] muzzles;

	//Laser Weapon Variables
	public GameObject laser;
	public float laserFireRate = 0.05f;
	private float laserFireTime;

	//Missile Weapon Variables
	public GameObject missile;
	public float missileFireRate = 1.0f;
	private float missileFireTime;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;

		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		playerPosition = myTransform.position;

		Movement ();

		CheckBoundary ();

		FireLasers ();

		FireMissiles ();

		myTransform.position = playerPosition;
	}

	//Shoot Secondary Missile Weapon
	private void FireMissiles (){
		if (Input.GetMouseButton (1) && Time.time > missileFireTime) {

			for (int index = 0; index < muzzles.Length; ++index) {
				Instantiate (missile, muzzles [index].transform.position, muzzles [index].transform.rotation);
			}
			missileFireTime = Time.time + missileFireRate;
		}
	}

	//Shoot Primary Laser weapon
	private void FireLasers(){
		if (Input.GetMouseButton (0) && Time.time > laserFireTime) {

			for (int index = 0; index < muzzles.Length; ++index) {
				Instantiate (laser, muzzles [index].transform.position, muzzles [index].transform.rotation);
			}
			laserFireTime = Time.time + laserFireRate;
		}
	}

	//Restrict Player Movement in Game World
	void CheckBoundary(){
		//Horizontal Boundary Check
		if (playerPosition.x <= -gameManager.xBoundary)
			playerPosition.x = -gameManager.xBoundary;
		else if (playerPosition.x >= gameManager.xBoundary)
			playerPosition.x = gameManager.xBoundary;

		//Vertical Boundary Check
		if (playerPosition.z <= -gameManager.zBoundary)
			playerPosition.z = -gameManager.zBoundary;
		else if (playerPosition.z >= gameManager.zBoundary)
			playerPosition.z = gameManager.zBoundary;

	}

	//Player Movement - keyboard controls
	void Movement (){

		//Movement: Left and Right
		if(Input.GetKey("a"))
			playerPosition.x = playerPosition.x - moveSpeed * Time.deltaTime;
		else if (Input.GetKey("d"))
			playerPosition.x = playerPosition.x + moveSpeed * Time.deltaTime;

		//Movement: Up and Down
		if(Input.GetKey("s"))
			playerPosition.z = playerPosition.z - moveSpeed * Time.deltaTime;
		else if (Input.GetKey("w"))
			playerPosition.z = playerPosition.z + moveSpeed * Time.deltaTime;
	}
}
