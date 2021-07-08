using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHealthManager : MonoBehaviour {
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public string enemyQuestName;
	private QuestManager theQM;
	public GameObject potion;
	public LevelManager levelManager;



	//private EnemyProjectile TheEP;

	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;
		theQM = FindObjectOfType<QuestManager> ();
		//TheEP = FindObjectOfType<EnemyProjectile> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyCurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;
			gameObject.SetActive (false);
			//GameObject.FindWithTag("enemybullet").GetComponent<EnemyProjectile>().enabled = false;
			//gameObject.GetComponent<EnemyProjectile>().enabled = false;
			Destroy(this.gameObject);
			UIManager._instance.EnemiesKilled ();
		


			enemyCurrentHealth = enemyMaxHealth;



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
