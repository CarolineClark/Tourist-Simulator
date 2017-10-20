using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assetSpawnMatrix : MonoBehaviour {

	string answer = "";
	public GameObject correct;
	public GameObject wrong;
	public GameObject correctcorrect;
	public GameObject wrongcorrect;
	public GameObject correctwrong;
	public GameObject wrongwrong;
	public GameObject correctcorrectcorrect;
	public Image speechBubbleBackground;
	GameObject prevObj = null;

	void Start () {
		speechBubbleBackground.enabled = false;
	}

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
			InstantiateWithTransform(correct);
		else if (answer == "wrong")
			InstantiateWithTransform(wrong);
		else if (answer == "correctcorrect")
			InstantiateWithTransform(correctcorrect);
		else if (answer == "correctwrong")
			InstantiateWithTransform(correctwrong);
		else if (answer == "wrongcorrect")
			InstantiateWithTransform(wrongcorrect);
		else if (answer == "wrongwrong")
			InstantiateWithTransform(wrongwrong);
		else if (answer == "correctcorrectcorrect")
			InstantiateWithTransform(correctcorrectcorrect);
	}

	private void InstantiateWithTransform(GameObject gObject) {
		if (prevObj != null) {
			Destroy(prevObj);
		}
		prevObj = Instantiate (gObject);
		prevObj.transform.SetParent(gameObject.transform);
		prevObj.transform.position = transform.position;

		speechBubbleBackground.enabled = true;
	}
}