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
			InstantiateGameObjectWithTransform(correct);
		else if (answer == "wrong")
			InstantiateGameObjectWithTransform(wrong);
		else if (answer == "correctcorrect")
			InstantiateGameObjectWithTransform(correctcorrect);
		else if (answer == "correctwrong")
			InstantiateGameObjectWithTransform(correctwrong);
		else if (answer == "wrongcorrect")
			InstantiateGameObjectWithTransform(wrongcorrect);
		else if (answer == "wrongwrong")
			InstantiateGameObjectWithTransform(wrongwrong);
		else if (answer == "correctcorrectcorrect")
			InstantiateGameObjectWithTransform(correctcorrectcorrect);
	}

	private void InstantiateGameObjectWithTransform(GameObject gObject) {
		if (prevObj != null) {
			Destroy(prevObj);
		}
		prevObj = Instantiate (gObject);
		prevObj.transform.SetParent(gameObject.transform);
		prevObj.transform.position = transform.position;
	}
}