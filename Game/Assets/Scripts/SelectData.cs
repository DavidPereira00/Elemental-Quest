using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectData : MonoBehaviour {
	private DialogueHolder dMAn;
	private QuestObject theQO;
	private EnemyHealthManager EHM;
	public int questNumber;
	public bool startQuest;
	public bool endQuest;
	public GameObject dailyq;
	public int dq;

		public string url = "http://localhost/android/getinfo.php";
		void Start()
		{
		questNumber = 3;
		dMAn = FindObjectOfType <DialogueHolder>();
		theQO = FindObjectOfType <QuestObject>();
		EHM = FindObjectOfType<EnemyHealthManager>();
		StartCoroutine(GetCharacterGalleryQue());

		}


		// Get the questions from the MySQL DB to display in a GUIText.
		// remember to use StartCoroutine when calling this function!
	/*public void InitiateQuest(){
		if (!theQM.questCompleted [questNumber]) 
		{
			if (startQuest && !theQM.quests [questNumber].gameObject.activeSelf)
			{
				theQM.quests [questNumber].gameObject.SetActive (true);
				//EHM.enemyQuestName = "Enemy";
				//theQM.quests [questNumber].StartQuest ();

			}
		}
	}*/


		IEnumerator GetCharacterGalleryQue()
		{
		
		gameObject.GetComponent<UnityEngine.UI.Text>().text = "Loading Scores";
			WWW hs_get = new WWW(url);
			yield return hs_get;

			if (hs_get.error != null)
			{
				print("There was an error getting the Character Data: " + hs_get.error);
			}
			else
			{
			dailyq.GetComponent<QuestObject> ().enabled = true;
			gameObject.GetComponent<UnityEngine.UI.Text>().text = hs_get.text;
			}
			//dq = 1;
			//gameObject.GetComponent<UnityEngine.UI.Text>().text = hs_get.text;
			//theQO.targetEnemy = hs_get.text;

		}
}

