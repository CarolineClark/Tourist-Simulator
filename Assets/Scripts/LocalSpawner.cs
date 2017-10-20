using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpawner : MonoBehaviour {

	public string assetName;
    public string animationName;
	private GameObject obj;


	// Use this for initialization
	void Start () {
		obj = Instantiate (Resources.Load<GameObject>(assetName));
		obj.transform.SetParent(gameObject.transform);
        if (animationName != null) {
            obj.GetComponent<Animator>().Play(animationName);
        }
	}

	void Destroy() {
		Destroy (obj);
	}
}
