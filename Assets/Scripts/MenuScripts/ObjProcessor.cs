using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjProcessor : MonoBehaviour {

	public ObjHolders holders = new ObjHolders();
	GameObject UIRoots;
	// Use this for initialization
	void Start () {
//		holders.Start ();
//		UIRoots = GameObject.Find ("Canvas");
//		holders.UIGameOver.SetActive (false);
//		holders.UIMainGame.SetActive (false);
//		holders.UIHelpScreen.SetActive (false);
//		holders.UIMainMenu.SetActive (false);
//		UIRoots.SetActive (false);
		//StartCoroutine (enableUI(1f));
//		holders.UIMainMenu.SetActive (false);

	}
	IEnumerator enableUI(float time){
		yield return new WaitForSeconds(time);
		UIRoots.SetActive(true);
//		holders.UIGameOver.SetActive (true);
//		holders.UIMainGame.SetActive (true);
//		holders.UIHelpScreen.SetActive (true);
		holders.UIMainMenu.SetActive (true);
//		TweenScale.Begin (holders.UIMainGame,0.1f,Vector3.zero);
//		TweenScale.Begin (holders.UIHelpScreen,0.1f,Vector3.zero);
//		TweenScale.Begin (holders.UIGameOver,0.1f,Vector3.zero);
	}
	// Update is called once per frame
	void Update () {
	
	}


}
