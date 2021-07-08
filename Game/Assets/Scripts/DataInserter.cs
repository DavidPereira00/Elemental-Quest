using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {

	// Use this for initialization
	public string inputUserName;
	public string inputPassword;
	public string inputEmail;

	string CreateUserURL = "http://localhost/InsertUser.php";

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			CreateUser (inputUserName, inputPassword, inputEmail);
	}

	public void CreateUser(string username, string password, string email){
		WWWForm form = new WWWForm ();
		form.AddField ("user_name", username);
		form.AddField ("password", password);
		form.AddField ("email", email);

		WWW www = new WWW(CreateUserURL, form);

	}
}