﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animCoke : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetTrigger("take");
	}
}
