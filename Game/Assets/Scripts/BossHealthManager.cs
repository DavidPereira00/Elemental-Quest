using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {
	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public string enemyQuestName;
	private QuestManager theQM;
	public GameObject potion;
	public LevelManager levelManager;
	public int remove;
	public GameObject wall;
	public GameObject enemy;
	private Player P;
	public float timer;




	//private EnemyProjectile TheEP;

	// Use this for initialization
	void Start () {
		enemyCurrentHealth = enemyMaxHealth;
		theQM = FindObjectOfType<QuestManager> ();
		remove = 0;
		P = FindObjectOfType<Player> ();
		//TheEP = FindObjectOfType<EnemyProjectile> ();
	}

	// Update is called once per frame
	void Update () {
		if (remove == 1) {
			timer += 1.0f * Time.deltaTime;
			enemy.SetActive (true);
			levelManager.RespawnPlayer ();
		}
		if (enemyCurrentHealth <= 0) {
			theQM.enemyKilled = enemyQuestName;
			gameObject.SetActive (false);
			//GameObject.FindWithTag("enemybullet").GetComponent<EnemyProjectile>().enabled = false;
			//gameObject.GetComponent<EnemyProjectile>().enabled = false;
			//Destroy(this.gameObject);
			UIManager._instance.EnemiesKilled ();
			P.bossd = 1;



			enemyCurrentHealth = enemyMaxHealth;



		}
		if (remove == 0) {
			timer = 0;
		}
		if (timer >= 3) {
			remove = 0;
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
