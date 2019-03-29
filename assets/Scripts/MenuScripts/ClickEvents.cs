using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour {
	public GameObject GameOver;
		public GameObject Help;
		public GameObject Sound;
	

		public GameObject SoundOn;
		public GameObject SoundOff;

		public GameObject pause;
		public GameObject resume;


		public Text Score;
		public Text HighScore;

		public GameObject ScorePlus;
	float timeDurationForTween = 0.3f;
	void Awake(){
		//sharedClickEvents = this;
	}

		void Start()
		{
				if (HighScore) {
						if (PlayerPrefs.GetInt (Constants.cons.kHighscore, 1) != 1) {
								Debug.Log ("Setting HighScore " + PlayerPrefs.GetInt (Constants.cons.kHighscore).ToString ());
									
								HighScore.text = PlayerPrefs.GetInt (Constants.cons.kHighscore).ToString ();
								Constants.cons.currentHighScore = PlayerPrefs.GetInt (Constants.cons.kHighscore);
						} else {
								Debug.LogError ("Setting 0 HighScore");

								Constants.cons.currentHighScore = 0;
								HighScore.text = Constants.cons.currentHighScore.ToString ();
								PlayerPrefs.SetInt (Constants.cons.kHighscore, Constants.cons.currentHighScore);
						}
				}

		}

	
	void prepareForNewGame(){

		Constants.cons.isGameStarted = true;
		Constants.cons.currentRound = 0;
		Constants.cons.score = 0;
		Constants.cons.isGameOver = false;
		//KeepCreatingObjects.sharedInstance.startNewRound ();

	}
	public void btnPlayPressed(){

		SoundManager.Instance.buttonClick();
		FindObjectOfType<FadeInOut> ().FadeIn ();
		SceneManager.LoadScene(1);

	}
	public void btnHelpPressed(){
//		TweenScale.Begin (ObjHolders.sharedObjects.UIHelpScreen, timeDurationForTween, Vector3.one);
//		TweenScale.Begin (ObjHolders.sharedObjects.UIMainMenu,timeDurationForTween,Vector3.zero);
				SoundManager.Instance.buttonClick();
				Help.SetActive (true);
		
	}

	public void btnSoundClicked(){
				SoundManager.Instance.buttonClick();
				SoundOn.SetActive (!SoundOn.activeSelf);
				SoundOff.SetActive (!SoundOff.activeSelf);
				if(SoundOn.activeInHierarchy)
				SoundManager.Instance.MuteMusic ();
				else
						SoundManager.Instance.UnMuteMusic ();	
	}


	//       Help Screnn Buttons
	public void btnCloseHelpClicked(){
		SoundManager.Instance.buttonClick();
//		TweenScale.Begin (ObjHolders.sharedObjects.UIHelpScreen,timeDurationForTween,Vector3.zero);
//		TweenScale.Begin (ObjHolders.sharedObjects.UIMainMenu,timeDurationForTween,Vector3.one);
				Help.SetActive (false);
		
	}

		public void btnCloseGameOverClicked(){
				SoundManager.Instance.buttonClick();
				//		TweenScale.Begin (ObjHolders.sharedObjects.UIHelpScreen,timeDurationForTween,Vector3.zero);
				//		TweenScale.Begin (ObjHolders.sharedObjects.UIMainMenu,timeDurationForTween,Vector3.one);
				SceneManager.LoadScene(0);

		}


	public void showGameOverScreen(){
				
//		TweenScale.Begin (ObjHolders.sharedObjects.UIMainGame,timeDurationForTween,Vector3.zero);
//		TweenScale.Begin (ObjHolders.sharedObjects.UIGameOver, timeDurationForTween, Vector3.one);
				GameOver.SetActive (true);
		
	}
	public void btnPlayAgainPressed(){
				SoundManager.Instance.buttonClick();
//		TweenScale.Begin (ObjHolders.sharedObjects.UIGameOver,timeDurationForTween,Vector3.zero);
//		TweenScale.Begin (ObjHolders.sharedObjects.UIMainGame, timeDurationForTween, Vector3.one);
		GameOver.SetActive (false);
				SceneManager.LoadScene(1);
	}

	public void btnPausePressed(){
				pause.SetActive (false);
				resume.SetActive (true);
		Time.timeScale = 0;
	}

	public void btnResumePressed(){
				resume.SetActive (false);
				pause.SetActive (true);
				Time.timeScale = 1;
	}


		public void SetScore(int score)
		{
				processForHighScore ();
				Score.text = ""+score;
		}


		public void SetScorePlus(int score)
		{
				GameObject g = Instantiate (ScorePlus, GameOver.transform.parent);
				g.GetComponent<Text> ().text = "+" + score;
				Destroy (g, 3f);
		}
		public void processForHighScore(){
				if(checkForHighScore(Constants.cons.score)){
						PlayerPrefs.SetInt (Constants.cons.kHighscore, Constants.cons.score);
						//ObjHolders.sharedObjects.lblHighScore.text = Constants.cons.score.ToString();
				}
		}
		public bool checkForHighScore(int score){
				if (Constants.cons.currentHighScore > score) {
						return false;
				} else 
						return true;
		}
}
