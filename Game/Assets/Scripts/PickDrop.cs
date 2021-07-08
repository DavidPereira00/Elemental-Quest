using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour {
	public int recoverToGive;

	void OnTriggerEnter2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			other.gameObject.GetComponent<PlayerHealthManager> ().RestoreHealth (recoverToGive);
			Destroy (this.gameObject);
		}
	}
}
