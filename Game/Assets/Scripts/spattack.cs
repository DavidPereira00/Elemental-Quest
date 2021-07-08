using System.Collections.Generic;
using UnityEngine;

public class spattack : MonoBehaviour {

	public bool playerA;
	public int damageToGive;
	float curTime = 0;
	public float attackRate;
	public float timer;
	private MeleePlayer MP;

	public DamageObject[] weapons;
	public int currentWeapon = 0;
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("OnTriggerEnter2D", 0f, 0.3f);
		MP=GetComponent<MeleePlayer>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			timer += 1.0f * Time.deltaTime;
		}
	}

	void OnTriggerStay2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (curTime <= 0) {

			if (other.gameObject.tag == "Enemy") {
					other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (weapons [currentWeapon].damage);
					Debug.Log ("this is curtime" + curTime);
					Debug.Log ("this is Attack Rate" + attackRate);
				}

			if (other.gameObject.tag == "boss") 
			{
				playerA = true;
				//yield return new WaitForSeconds (1);
				if (playerA) {
					other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
					Debug.Log ("this is curtime" + curTime);
					Debug.Log ("this is Attack Rate" + attackRate);
				}
			}
			if (other.gameObject.tag == "Fboss") 
			{
				playerA = true;
				//yield return new WaitForSeconds (1);
				if (playerA) {
					other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
					Debug.Log ("this is curtime" + curTime);
					Debug.Log ("this is Attack Rate" + attackRate);
				}
			}
			if (other.gameObject.tag == "Fboss2") 
			{
				playerA = true;
				//yield return new WaitForSeconds (1);
				if (playerA) {
					other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
					Debug.Log ("this is curtime" + curTime);
					Debug.Log ("this is Attack Rate" + attackRate);
				}
				//thePlayer.canMove = false;
			}
			if (other.gameObject.tag == "wall") 
			{
				playerA = true;
				//yield return new WaitForSeconds (1);
				if (playerA) {
					other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
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
		if (other.gameObject.name == "Enemy") 
		{
			
		}
	}
}

