using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamageObject : ScriptableObject {

	public string itemName = "Item Name Here";
	public int cost = 50;
	public string description;

	public int damage = 60;
}