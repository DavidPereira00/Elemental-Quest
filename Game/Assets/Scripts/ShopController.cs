using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

	public Canvas shopCanvas;
	public int shop;
	private Player P;
	private MeleePlayer MP;

	void Start () {
		shop = 0;
		P = FindObjectOfType<Player> ();
		MP = FindObjectOfType<MeleePlayer> ();
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			if (Input.GetKeyUp (KeyCode.Z) && shop==0) {
				OpenShop ();
				shop = 1;
			}
			else if (Input.GetKeyUp (KeyCode.Z) && shop==1) {
				CloseShop ();
				shop = 0;
			}
		}
	}

	void OpenShop ()
	{
		shopCanvas.enabled = true;
		//Time.timeScale = 0;
		P.canMovee=false;
	}

	public void CloseShop(){
		
			shopCanvas.enabled = false;
			//Time.timeScale = 1;
		P.canMovee=true;

	}

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}
}
