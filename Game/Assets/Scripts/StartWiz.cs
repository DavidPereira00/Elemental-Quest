using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWiz : MonoBehaviour {

	public void changemenuscene(string scenename){
		Application.LoadLevel (scenename);
	}
}
