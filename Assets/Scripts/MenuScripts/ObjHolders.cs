using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[System.Serializable]
public class ObjHolders  {

	public static ObjHolders sharedObjects;
	public GameObject UIMainMenu;
	public GameObject UIMainGame;

	// Main Game Play 
	public GameObject btnSoundOn;
	public GameObject btnSoundOff;

	// Help Screen 
	public GameObject UIHelpScreen;
	//Game Over Screen
	public GameObject UIGameOver;

	public GameObject lblRound;
	public Text lblScore;
	public Text lblHighScore;
	// Use this for initialization
	public virtual void Start () {
//		Debug.Log ("STARTT METOD CALLED ***********************************");
//		sharedObjects = this;
//		UIMainMenu = GameObject.Find ("MainMenu");
//		UIMainGame = GameObject.Find ("MainGame");
//
//		//Main Game Play Buttons
//		btnSoundOn  =  GameObject.Find ("btnSoundOn");
//		btnSoundOff =  GameObject.Find ("btnSoundOff");
//		btnSoundOff.SetActive (false);
//
//		// Help Screen 
//		UIHelpScreen = GameObject.Find ("HelpScreen");
//
//		UIGameOver = GameObject.Find ("GameOver");
//
//		lblRound = GameObject.Find (UIMainGame.name + "/lblRound"); 
//		lblScore = GameObject.Find ("MainGame/lblScore/Label").GetComponent<Text> ();
//		lblHighScore = GameObject.Find ("MainGame/lblHighScore/Label").GetComponent<Text> ();
	}	

	public ObjHolders(){
		sharedObjects = this;
	}
}
