using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingCokeScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//anim.Play;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
		{
			anim.SetTrigger("fall");

		}
	}
}
