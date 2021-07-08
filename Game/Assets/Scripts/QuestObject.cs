using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNumber;
	public QuestManager TheQM;
	public DialogueManager TheDM;
	private DialogueManager dMAn;
	//private NPC TheN;
	public string startText;
	public string endText;
	public bool isItemQuest;
	public string targetItem;
	public bool isEnemyQuest;
	public bool isdailyquest;
	public bool isBossQuest;
	public bool isDropQuest;
	public bool isTalkQuest;
	public string targetEnemy;
	public int enemiesToKill;
	public int enemyKillCount;
	public string drop;
	public int dropfound;
	public int droptofind;
	public GameObject dzone;
	public GameObject zoned;
	//public GameObject playerObject;
	// Use this for initialization
	void Start () {
		TheDM = FindObjectOfType<DialogueManager>();

		//TheN = FindObjectOfType<NPC>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isItemQuest) 
		{
			if (TheQM.itemCollected == targetItem) 
			{
				TheQM.itemCollected = null;
				//TheQM.ShowQuestText (endText);
				FinishQuest ();
				//playerObject.GetComponent<DialogueHolder>().enabled = false;
				dzone.SetActive (false);
				zoned.SetActive (true);
				//UIManager._instance.CollectedCoin ();
				//TheN.questNumber = 1;
				//Instantiate (NPC, Vector3 (64, 136, 0), transform.rotation);
			}
		}
		if (isEnemyQuest) 
		{
			if (TheQM.enemyKilled == targetEnemy) 
			{
				TheQM.enemyKilled = null;
				enemyKillCount++;
			}
			if (enemyKillCount >= enemiesToKill) 
			{
				FinishQuest ();
				dzone.SetActive (false);
				zoned.SetActive (true);
				//TheN.questNumber = 1;

			}
		}
		if (isdailyquest) 
		{
			if (TheQM.enemyKilled == targetEnemy) 
			{
				TheQM.enemyKilled = null;
				enemyKillCount++;
				UIManager._instance.CollectedCoin ();
			}
			if (enemyKillCount >= enemiesToKill) 
			{
				//TheN.questNumber = 1;
			}
		}
		if (isBossQuest) 
		{
			if (TheQM.enemyKilled == targetEnemy) 
			{
				TheQM.enemyKilled = null;
				enemyKillCount++;
				FinishQuest ();
				dzone.SetActive (false);
				zoned.SetActive (true);
			}
			if (enemyKillCount >= enemiesToKill) 
			{
				//TheN.questNumber = 1;
			}
		}
		if (isDropQuest) 
		{
			if (TheQM.itemCollected == targetItem) 
			{
				TheQM.itemCollected = null;
				dropfound++;
			}
			if (dropfound >= droptofind) 
			{
				FinishQuest ();
				dzone.SetActive (false);
				zoned.SetActive (true);

				//TheN.questNumber = 1;
			}
		}
		if (isTalkQuest) 
		{
			if (TheQM.talked==1) 
			{
				
				//TheQM.ShowQuestText (endText);
				FinishQuest ();
				//playerObject.GetComponent<DialogueHolder>().enabled = false;
				dzone.SetActive (false);
				zoned.SetActive (true);
				//UIManager._instance.CollectedCoin ();
				//TheN.questNumber = 1;
				//Instantiate (NPC, Vector3 (64, 136, 0), transform.rotation);
			}
		}
	}

	public void StartQuest(){
		//TheQM.ShowQuestText (startText);
	}

	public void FinishQuest(){
		//TheQM.ShowQuestText (endText);
	}
		
	public void EndQuest(){
		//TheQM.ShowQuestText (endText);
		TheQM.questCompleted [questNumber] = true;
		gameObject.SetActive (false);
	}
}
