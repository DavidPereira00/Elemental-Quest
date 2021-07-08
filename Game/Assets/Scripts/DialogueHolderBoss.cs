using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolderBoss : MonoBehaviour {

	public int questNumber;
	public string dialogue;
	private DialogueManager dMAn;
	private QuestManager theQM;
	private EnemyHealthManager EHM;
	private NPC theNPC;
	public bool startQuest;
	public bool endQuest;
	public GameObject dzone;
	public GameObject boss;
	public int refd;

	public bool bulletOf = false;

	public string[] dialogueLines;

	// Use this for initialization
	void Start () {
		dMAn = FindObjectOfType <DialogueManager>();
		theQM = FindObjectOfType <QuestManager>();
		theNPC = FindObjectOfType<NPC>();
		EHM = FindObjectOfType<EnemyHealthManager>();
		refd = 0;
	}

	// Update is called once per frame
	void Update () {

		/*if (dMAn.currentLine >= dMAn.dialogLines.Length) {
			InitiateQuest ();
		}*/

	}

	void OnTriggerStay2D (Collider2D other){ //if it collides with the player, shows dialogue
		if (other.gameObject.name == "Player") 
		{
			if (Input.GetKeyUp (KeyCode.Z))
			{
				//dMAn.ShowBox (dialogue);
				bulletOf = true;
				if (!dMAn.dialogActive) {
					dMAn.dialogLines = dialogueLines;
					dMAn.currentLine = 0;
					InitiateQuest ();
					dMAn.ShowDialogue();
					gameObject.SetActive (false);
					dzone.SetActive (true);
					boss.SetActive (true);
					refd = 1;
				}
			}
		}
	}

	public void InitiateQuest(){
		if (!theQM.questCompleted [questNumber]) 
		{
			if (startQuest && !theQM.quests [questNumber].gameObject.activeSelf) 
			{
				theQM.quests [questNumber].gameObject.SetActive (true);
				//EHM.enemyQuestName = "Enemy";
				//theQM.quests [questNumber].StartQuest ();
			}
		}
	}
}
