using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assetSpawnMatrix : MonoBehaviour {

	public readonly string CORRECT = "correct";
	public readonly string WRONG = "wrong";
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

	public void AnswerQuestionWrong() {
		Debug.Log("answered question wrong");
		AnswerQuestion(WRONG);
	}

	public void AnswerQuestionCorrect() {
		Debug.Log("answered question correct");
		AnswerQuestion(CORRECT);
	}

	private void AnswerQuestion (string answer) {
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