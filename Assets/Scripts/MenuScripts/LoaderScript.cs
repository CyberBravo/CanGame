using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LoaderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (loadnextScene(1.0f));
	}

	IEnumerator loadnextScene(float time)
	{
		yield return new WaitForSeconds (time);
		Application.LoadLevel (1);
	}
}
