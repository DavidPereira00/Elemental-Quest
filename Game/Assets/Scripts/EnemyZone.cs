using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour {

	public bool enemyZ;


	// Use this for initialization
	void Start () {
		enemyZ = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){ 
		if (other.gameObject.name == "Player") 
		{
			enemyZ = true;
		}
	}

	void OnTriggerExit2D (Collider2D other){ 
		if (other.gameObject.name == "Player") 
		{
			enemyZ = false;
		}
	}
}
