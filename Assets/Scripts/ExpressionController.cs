using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionController : MonoBehaviour {

	public GameObject regular;
	public GameObject puzzled;
	public GameObject angry;
	private GameObject currentExpression;

	// Use this for initialization
	void Start () {
		SetRegular();
	}

	private void HideAllSprites() {
		regular.SetActive(false);
		puzzled.SetActive(false);
		angry.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetRegular() {
		HideAllSprites();
		SetExpression(regular);
	}

	public void SetPuzzled() {
		HideAllSprites();
		SetExpression(puzzled);
	}

	public void SetAngry() {
		HideAllSprites();
		SetExpression(angry);
	}

	private void SetExpression(GameObject expression) {
		currentExpression = expression;
		currentExpression.SetActive(true);
	}
}
