using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss2HealthManager : MonoBehaviour {
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public string enemyQuestName;
	private QuestManager theQM;
	public GameObject potion;
	public LevelManager levelManager;
	private Player P;
	private MeleePlayer MP;




	//private EnemyProjectile TheEP;

	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;
		theQM = FindObjectOfType<QuestManager> ();
		P = FindObjectOfType<Player> ();
		MP = FindObjectOfType<MeleePlayer> ();
		//TheEP = FindObjectOfType<EnemyProjectile> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyCurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;
			gameObject.SetActive(false);
			P.enemykilled = P.enemykilled + 1;
			MP.enemykilled = MP.enemykilled + 1;
			//Destroy(this.gameObject);
			UIManager._instance.EnemiesKilled ();


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
