using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttSpawner : MonoBehaviour {
	public GameObject butt;
	public int numberOfButts = 30;
	public float delayBetweenSpawns = 0.1f;
	public float sphereRadius = 2.0f;

	void Start () {
		StartCoroutine (LaunchButts ());
	}

	IEnumerator LaunchButts() {
		for (int i=0; i<numberOfButts; i++) {
			GameObject gObject = new GameObject ();
			Transform t = gObject.transform;
			t.position = (sphereRadius * Random.onUnitSphere) + transform.position;
			GameObject newButt = GameObject.Instantiate (butt, t);
			newButt.transform.localScale *= (Random.value + 0.7f);
			yield return new WaitForSeconds(delayBetweenSpawns);
		}
		yield return new WaitForSeconds(delayBetweenSpawns);
	}
}
