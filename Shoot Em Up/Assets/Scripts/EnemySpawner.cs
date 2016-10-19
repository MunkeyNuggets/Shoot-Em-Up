using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public float spawnInterval = 1.0f;
	private float spawnTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Spawn Timer
		if (Time.time > spawnTimer) {
			Instantiate (enemy, transform.position, transform.rotation);
			spawnTimer = Time.time + spawnInterval;
		}
	
	}
}
