using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSpawner : MonoBehaviour {
	private static LocalSpawner localSpawner;
	public static LocalSpawner instance  
    {
        get
        {
            if (!localSpawner) 
            {
				localSpawner = FindObjectOfType (typeof (LocalSpawner)) as LocalSpawner;
                if (!localSpawner)
                {
                    Debug.LogError("Need an active EventManager on a GameObject in your scene");
                }
            }
            return localSpawner;
        }
    }

	public string assetName;
	private GameObject obj;

	// Use this for initialization
	void Start () {
		obj = Instantiate (Resources.Load<GameObject>(assetName));
		obj.transform.SetParent(gameObject.transform);
	}

	void Destroy() {
		Destroy (obj);
	}
}
