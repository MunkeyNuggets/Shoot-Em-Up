using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float zBoundary = 50.0f;
	public float xBoundary = 150.0f;

	public GameObject[] enemies;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Update enemy list
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}
}
