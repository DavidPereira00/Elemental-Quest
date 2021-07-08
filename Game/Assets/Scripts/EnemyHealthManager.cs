using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public string enemyQuestName;
	private QuestManager theQM;
	public GameObject potion;
	public LevelManager levelManager;
	private Player P;




	//private EnemyProjectile TheEP;

	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;
		theQM = FindObjectOfType<QuestManager> ();
		P = FindObjectOfType<Player> ();
		//TheEP = FindObjectOfType<EnemyProjectile> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyCurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;
			gameObject.SetActive(false);
			//Destroy(this.gameObject);
			UIManager._instance.EnemiesKilled ();
			if (Random.value > 0.5f) {
				Instantiate (potion, transform.position, Quaternion.identity);
			}


			enemyCurrentHealth = enemyMaxHealth;

			levelManager.RespawnSpider ();

		}

	}

	public void Projectile(int damageToGive)
	{
		enemyCurrentHealth-= damageToGive;
	}

	public void HurtEnemy(int damageToGive)
	{
		enemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		enemyCurrentHealth = enemyMaxHealth;
	}
}