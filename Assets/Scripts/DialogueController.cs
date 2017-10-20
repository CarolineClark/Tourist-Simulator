using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {

	public Text narration;
	public Text localLine;
	public Text touristLine;
	public Text questionLine;
	public Button questionButton1;
	public Text questionButton1Text;
	public Button questionButton2;
	public Text questionButton2Text;
	public ExpressionController tourist;
	public ExpressionController local;
	public assetSpawnMatrix spawnMatrix;

	DialogueConfig config;
	DialogueState state;
	int question = 1;
	int wrongAnswers = 0;
	Answer[] answers = null;
	bool rightIsCorrect = true;

	// Use this for initialization
	void Start () {
		
		TextAsset data = Resources.Load ("german") as TextAsset;
		string dataString = data.ToString ();

		config = JsonUtility.FromJson<DialogueConfig> (dataString);
		answers = new Answer[config.MaxLines];
		for (int i = 0; i < answers.Length; ++i)
			answers [i] = Answer.None;
	
		narration.text = config.narration;
		localLine.gameObject.SetActive (false);
		touristLine.gameObject.SetActive (false);
		questionLine.gameObject.SetActive (false);
		questionButton1.gameObject.SetActive (false);
		questionButton2.gameObject.SetActive (false);

		questionButton1.onClick.AddListener(delegate() {OnClick (questionButton1);});
		questionButton2.onClick.AddListener(delegate() {OnClick (questionButton2);});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if (state == DialogueState.Narration) {
				HideNarration ();
				ShowQuestion (question);
			} else if (state == DialogueState.Answer1 ||
			         state == DialogueState.Answer2 ||
					(state == DialogueState.Answer3 && config.MaxLines == 4)) {
				ShowQuestion (question);
			} else if ((state == DialogueState.Answer3 && config.MaxLines == 3) ||
			         state == DialogueState.Answer4) {
				FinishScene ();
			}
		}
	}

	void HideNarration() {
		narration.gameObject.SetActive (false);
	}
	void ShowQuestion (int question) {
		questionLine.gameObject.SetActive (true);
		questionButton1.gameObject.SetActive (true);
		questionButton2.gameObject.SetActive (true);

		localLine.gameObject.SetActive (false);
		touristLine.gameObject.SetActive (false);

		DialogueLine currLine = config.GetLine (question);

		questionLine.text = currLine.question_base;

		rightIsCorrect = (Random.Range (0f, 1f) > 0.5f) ? true : false;

		if (rightIsCorrect) {
			questionButton1Text.text = currLine.question_wrong;
			questionButton2Text.text = currLine.question_right;
		} else {
			questionButton2Text.text = currLine.question_wrong;
			questionButton1Text.text = currLine.question_right;
		}
		IncrementState();
	}

	public void OnClick (Button button) {
		if (button == questionButton1) {
			PressedQuestionButton1();
		} else if (button == questionButton2) {
			PressedQuestionButton2();
		} else
			Debug.LogError ("Map the damn button in Dialogue GO!");

		AnswerQuestion (button);
	}

	private void PressedQuestionButton1() {
		Debug.Log("clicking button 1");
		local.SetRegular();
		spawnMatrix.AnswerQuestionCorrect();
	}

	private void PressedQuestionButton2() {
		Debug.Log("clicking button 1");
		local.SetPuzzled();
		spawnMatrix.AnswerQuestionWrong();
	}

	public void AnswerQuestion (Button button) {

		bool isCorrect = CheckAnswer (button);

		questionLine.gameObject.SetActive (false);
		questionButton1.gameObject.SetActive (false);
		questionButton2.gameObject.SetActive (false);

		touristLine.text = config.GetQuestion (question, isCorrect);
		localLine.text = config.GetAnswer (question, isCorrect);

		++question;
		IncrementState();

		localLine.gameObject.SetActive (true);
		touristLine.gameObject.SetActive (true);
	}

	bool CheckAnswer (Button button) {

		bool isCorrect;
		if (button == questionButton1)
			isCorrect = !rightIsCorrect;
		else
			isCorrect = rightIsCorrect;

		if (!isCorrect)
			++wrongAnswers;

		answers [question-1] = isCorrect ? Answer.Right : Answer.Wrong;
		return isCorrect;
	}

	public void FinishScene () {
		Debug.LogError ("FINISHED");
	}

	void IncrementState () {
		//string stateChange = "state change. before: " + state.ToString () + " -- ";
		++state;
		//stateChange += "after: " + state.ToString ();
		//Debug.Log (stateChange);
	}
}

public enum DialogueState {
	Narration,
	Question1,
	Answer1,
	Question2,
	Answer2,
	Question3,
	Answer3,
	Question4,
	Answer4
}

public enum Answer {
	None,
	Right,
	Wrong
}