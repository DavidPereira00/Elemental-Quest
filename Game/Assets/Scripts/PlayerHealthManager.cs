using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
	public int playerMaxHealth;
	public int playerCurrentHealth;
	public LevelManager levelManager;

	public ShopObject[] items;
	public int currentItem = 0;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		playerCurrentHealth = items[currentItem].maxHealth;
		playerMaxHealth = items[currentItem].maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			playerCurrentHealth = items[currentItem].maxHealth;
			levelManager.RespawnPlayer ();

			//gameObject.SetActive (false);
		}
		
	}

	public void RestoreHealth(int recoverToGive)
	{
		if (items[currentItem].maxHealth > playerCurrentHealth) {
			playerCurrentHealth = playerCurrentHealth + recoverToGive;
		}
		if (playerCurrentHealth > items[currentItem].maxHealth) {
			playerCurrentHealth = items[currentItem].maxHealth;
		}
	}

	public void EnemyAttack(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;

	}

	public void EnemyProjectile(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
		AudioSource hit = GetComponent<AudioSource> ();
		hit.Play ();
	}


}
