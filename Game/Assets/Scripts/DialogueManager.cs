using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;


	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	public string[] dialogLines2;
	public int currentLine2;

	private DialogueHolder DH;
	private Player thePlayer;
	private MeleePlayer theMPlayer;
	private QuestManager theQM;
	private NPC theNPC;
	private NPC2 theNPC2;
	//public int questNumber;
	public bool startQuest;
	public bool endQuest;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Player>();
		theMPlayer = FindObjectOfType<MeleePlayer>();
		theQM = FindObjectOfType<QuestManager>();
		theNPC = FindObjectOfType<NPC>();
		theNPC2 = FindObjectOfType<NPC2>();
		DH = FindObjectOfType<DialogueHolder> ();
	}

	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyUp(KeyCode.Z))//deactivation of the box message and dialogue
		{
			//dBox.SetActive (false);
			//dialogActive = false;

			currentLine++;
			currentLine2++;
		}

		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;
			thePlayer.canMovee = true;
			theMPlayer.canMove = true;
			//DH.InititateQuest ();
			/*if (!theQM.questCompleted [theNPC.questNumber]) 
			{
				if (startQuest && !theQM.quests [theNPC.questNumber].gameObject.activeSelf) 
				{
					theQM.quests [theNPC.questNumber].gameObject.SetActive (true);
					//theQM.quests [questNumber].StartQuest ();
				}
			}/*
			if (!theQM.questCompleted [theNPC2.questNumber2]) 
			{
				if (startQuest && !theQM.quests [theNPC2.questNumber2].gameObject.activeSelf) 
				{
					theQM.quests [theNPC2.questNumber2].gameObject.SetActive (true);
					//theQM.quests [questNumber].StartQuest ();
				}
			}*/
		}
	/*
			if (!theQM.questCompleted [theNPC2.questNumber2]) 
			{
				if (startQuest && !theQM.quests [theNPC2.questNumber2].gameObject.activeSelf) 
				{
					theQM.quests [theNPC2.questNumber2].gameObject.SetActive (true);
					//theQM.quests [questNumber].StartQuest ();
				}
			}*/
		
		dText.text = dialogLines [currentLine];
	}
	/*public void ShowBox (string dialogue) {//activation of the  box message and dialogue
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}*/

	public void ShowDialogue(){
		dialogActive = true;
		dBox.SetActive (true);
		thePlayer.canMovee = false;
		theMPlayer.canMove = false;

	}
}

