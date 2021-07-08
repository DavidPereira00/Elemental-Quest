using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

	public PlayerHealthManager player;
	public Projectile projec;
	public int itemNumber;


	public Text name;
	public Text cost;
	public Text description;

	private AudioSource source;
	public PlayerHealthManager theph;
	public UIManager uim;
	public int a;
	public int b;
	// Use this for initialization
	void Start () 
	{
		source = GetComponent<AudioSource> ();
		//uim = GetComponent<UIManager> ();
		a=4;
		b = 1;
	}


	void SetButton()
	{
		/*string costString = player.items [itemNumber].cost.ToString();
		name.text = player.items [itemNumber].name;
		cost.text = player.items [itemNumber].cost + " $";
		description.text = player.items [itemNumber].description;*/
		string costString = projec.weapons [itemNumber].cost.ToString();
		name.text = projec.weapons [itemNumber].name;
		cost.text = projec.weapons [itemNumber].cost + " $";
		description.text = projec.weapons [itemNumber].description;
	}


	public void OnClick()
	{
		/*if (uim.coinsCollected >= player.items [itemNumber].cost) {

			uim.coinsCollected=uim.coinsCollected-player.items [itemNumber].cost;
			uim.Coins.text = "Coins: " + uim.coinsCollected ;
			//player.currentItem = itemNumber;
			player.currentItem = itemNumber;
			theph.playerCurrentHealth = theph.items[theph.currentItem].maxHealth;
			theph.playerMaxHealth = theph.items[theph.currentItem].maxHealth;
		}*/
		if (uim.coinsCollected >= projec.weapons [itemNumber].cost) {

			uim.coinsCollected=uim.coinsCollected-player.items [itemNumber].cost;
			uim.Coins.text = "Coins: " + uim.coinsCollected ;
			//player.currentItem = itemNumber;
			projec.currentWeapon = itemNumber;
			//theph.playerCurrentHealth = theph.items[theph.currentItem].maxHealth;
			//theph.playerMaxHealth = theph.items[theph.currentItem].maxHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
