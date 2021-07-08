using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmov : MonoBehaviour {
	
	public DialogueHolderBoss DHB;

	// Use this for initialization
	void Start () {

	}







	// Update is called once per frame
	void Update () {

		if (DHB.refd==1)
		{
			GetComponent<BossProjectile> ().enabled = true;
		}
	}
}

