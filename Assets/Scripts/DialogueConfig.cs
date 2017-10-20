using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class DialogueConfig
{
	int MAX_LINES = 4;

	public string language;
	public string narration;
	public Dialogue dialogue;
	int maxLines = 0;

	public string GetQuestion (int questionId, bool isRight) {

		DialogueLine currLine = GetLine (questionId);
		
		string text = currLine.question_base;
		if (isRight)
			text += currLine.question_right;
		else
			text += currLine.question_wrong;

		return text;
	}

	public string GetAnswer (int questionId, bool isRight) {

		DialogueLine currLine = GetLine (questionId);
		string text = "";

		if (isRight)
			text += currLine.response_right;
		else
			text += currLine.response_wrong;

		return text + currLine.response_either;
	}

	public DialogueLine GetLine (int questionId) {
		if (questionId == 1)
			return dialogue.line1;
		if (questionId == 2)
			return dialogue.line2;
		if (questionId == 3)
			return dialogue.line3;
		if (questionId == 4)
			return dialogue.line4;

		Debug.LogError ("Incorrect question ID");
		return null;
	}

	public int MaxLines {
		get {
			if (maxLines == 0)
				maxLines = FindMaxLine ();
			return maxLines;
		}
	}

	int FindMaxLine() {
		for (int i = 1; i < MAX_LINES; ++i) {
			DialogueLine line = GetLine (i);
			if (line.response_either == "")
				return i;
		}
		return MAX_LINES;
	}
}

[Serializable]
public class Dialogue {
	public DialogueLine line1;
	public DialogueLine line2;
	public DialogueLine line3;
	public DialogueLine line4;
}

[Serializable]
public class DialogueLine {
	public string question_base;
	public string question_right;
	public string question_wrong;
	public string response_right;
	public string response_wrong;
	public string response_either;
}
