using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private Player player;
	private AIZ spider;
	private AIZ wolf;
	public GameObject currentSpiderSpawn1;
	public GameObject currentWolfSpawn1;
	private BossHealthManager BHM;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player> ();
		spider = FindObjectOfType<AIZ> ();
		BHM = FindObjectOfType<BossHealthManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer()
	{
		Debug.Log ("Player Respawn");
//		BHM.remove = 0;
		player.transform.position = currentCheckpoint.transform.position;
	}
	public void RespawnSpider ()
	{
		Debug.Log ("Spider Respawn");

		spider.transform.position = currentSpiderSpawn1.transform.position;
	}
	public void RespawnWolf()
	{
		Debug.Log ("Wolf Respawn");

		wolf.transform.position = currentWolfSpawn1.transform.position;
	}


}
