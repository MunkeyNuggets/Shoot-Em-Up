using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameManager gameManager;

	public GameObject player;

	public float health = 100.0f;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Base Enemy take damage functionality
	public virtual void TakeDamage(float damage){
		health -= damage;

		if (health <= 0)
			Destroy (this.gameObject);
	}
}
