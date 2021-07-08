using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager _instance;
	public Slider healthBar;
	public Slider spatk;
	public Text HPText;
	public PlayerHealthManager playerHealth;
	public PlayerHealthManager player;
	public GlobalControl GH;
	public Text Coins;
	public int coinsCollected;
	private int coinsTotal;
	public int enemiesKilled;
	public int currentItem=0;
	public int itemNumber;

	public Text name;
	public Text cost;
	public Text description;
	// Use this for initialization

	void Awake(){
		_instance = this;
	}

	void Start () {
		coinsCollected = 0;
		Coins.text = "Coins: " + coinsCollected;
	}

	// Update is called once per frame
	void Update () {
		healthBar.value = playerHealth.playerCurrentHealth;
		healthBar.maxValue = playerHealth.playerMaxHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		spatk.value = enemiesKilled;
		//coinsCollected = coinsCollected-player.items [itemNumber].cost;
	}

	/*void SetButton()
	{
		string costString = player.items [itemNumber].cost.ToString();
		name.text = player.items [itemNumber].name;
		cost.text = player.items [itemNumber].cost + " $";
		description.text = player.items [itemNumber].description;
	}


	public void OnClick()
	{
		if (coinsCollected >= player.items [itemNumber].cost) {

			coinsCollected = player.items [itemNumber].cost;
		//player.currentItem = itemNumber;
			player.currentItem = itemNumber;
		}
	}*/


	public void CollectedCoin(){
		coinsCollected= coinsCollected + 50;
		Coins.text = "Coins: " + coinsCollected ;

	}
	public void EnemiesKilled(){
		enemiesKilled = enemiesKilled + 50;
	}
}