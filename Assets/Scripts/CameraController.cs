using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 origPos;
	float shake;
	public float decreaseFactor = 2f;
	public float magnitude = 0.5f;

	void Start () {
		origPos = transform.position;
    }
	
	void Update () {
		transform.position = origPos;

		if (shake > 0) {
			transform.localPosition = Random.insideUnitSphere * shake + origPos;
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0.0f;
		}
	}

	public void ScreenShake() {
		Debug.Log("screen shake");
		shake = magnitude;
	}
}
