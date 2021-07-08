using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public bool enemyA;
	public int damageToGive;
	float curTime = 0;
	public float attackRate;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("OnTriggerEnter2D", 0f, 0.3f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (curTime <= 0) {
			
			if (other.gameObject.name == "Player") {
			
				enemyA = true;
				//yield return new WaitForSeconds (1);
				if (enemyA) {
					other.gameObject.GetComponent<PlayerHealthManager> ().EnemyAttack (damageToGive);
					Debug.Log ("this is curtime" + curTime);
					Debug.Log ("this is Attack Rate" + attackRate);
				}
		
			}
			curTime = attackRate;
			} else {
			curTime -= Time.deltaTime;
		} 
			
	}

	void OnTriggerExit2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			enemyA = false;
		}
	}
}
