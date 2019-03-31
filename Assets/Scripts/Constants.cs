using UnityEngine;
using System.Collections;

public class Constants : MonoBehaviour {
	public static Constants cons;

	public bool isGameStarted;
	public bool isGamePaused;
	public bool isNewRoundStarted;
	public bool isGameOver;
	public int currentRound;
	public int score;
	public string kHighscore = "highScores";
	public int currentHighScore;
	void Awake(){
		cons = this;
	}
	// Use this for initialization
	void Start () {
		isGameStarted = false;
		isGameOver = false;
		currentRound = 0;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
