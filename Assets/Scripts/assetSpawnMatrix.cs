using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assetSpawnMatrix : MonoBehaviour {

	private string answer = "";
	public readonly string CORRECT = "correct";
	public readonly string WRONG = "wrong";
	// public GameObject correct;
	// public GameObject wrong;
	// public GameObject correctcorrect;
	// public GameObject wrongcorrect;
	// public GameObject correctwrong;
	// public GameObject wrongwrong;
	// public GameObject correctcorrectcorrect;
	public Image speechBubbleBackground;
	GameObject prevObj = null;

	void Start () {
		speechBubbleBackground.enabled = false;
	}

	public void ShowStart(string language) {
		InstantiateWithTransform(Resources.Load(language + "/start") as GameObject);
	}

	public void AnswerQuestionWrong(string language) {
		Debug.Log("answered question wrong");
		answer += WRONG;
		AnswerQuestion(language, answer);
	}

	public void AnswerQuestionCorrect(string language) {
		Debug.Log("answered question correct");
		answer += CORRECT;
		AnswerQuestion(language, answer);
	}

	private void AnswerQuestion (string language, string answer) {
		if (prevObj != null)
			Destroy (prevObj);

		InstantiateWithTransform(Resources.Load(language + "/" + answer) as GameObject);
		speechBubbleBackground.enabled = true;

		/*

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
			*/
	}

	private void InstantiateWithTransform(GameObject gObject) {
		if (prevObj != null) {
			Destroy(prevObj);
		}
		prevObj = Instantiate (gObject);
		prevObj.transform.SetParent(gameObject.transform);
		prevObj.transform.position = transform.position;
	}
}