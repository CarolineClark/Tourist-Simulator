using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assetSpawnMatrix : MonoBehaviour {

	string answer = "";
	public GameObject correct;
	public GameObject wrong;
	public GameObject correctcorrect;
	public GameObject wrongcorrect;
	public GameObject correctwrong;
	public GameObject wrongwrong;
	public GameObject correctcorrectcorrect;

	GameObject prevObj = null;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		bool didChange = false;
		if (Input.GetKeyDown (KeyCode.Q)) {
			answer += "correct";
			didChange = true;
		} else if (Input.GetKeyDown (KeyCode.W)) {
			answer += "wrong";
			didChange = true;
		}

		if (didChange)
			AnswerQuestion (answer);
	}

	public void AnswerQuestion (string answers) {
		if (prevObj != null)
			Destroy (prevObj);
		
		if (answer == "correct")
			prevObj = Instantiate (correct);
		else if (answer == "wrong")
			prevObj = Instantiate (wrong);
		else if (answer == "correctcorrect")
			prevObj = Instantiate (correctcorrect);
		else if (answer == "correctwrong")
			prevObj = Instantiate (correctwrong);
		else if (answer == "wrongcorrect")
			prevObj = Instantiate (wrongcorrect);
		else if (answer == "wrongwrong")
			prevObj = Instantiate (wrongwrong);
		else if (answer == "correctcorrectcorrect")
			prevObj = Instantiate (correctcorrectcorrect);
	}
}