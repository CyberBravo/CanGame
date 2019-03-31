using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class KeepCreatingObjectsOld : MonoBehaviour
{
	private GameObject cans;

	private GameObject sparkEffect;

	private float[] yPosvalue = new float[]
	{
		0.4f,
		0.45f,
		0.5f,
		0.55f
	};

	private bool isClicked;

	private int numberOfCansCreated;

	private float cansTimer;

	private float cansTimerTarget = 2f;

	private float roundTimer;

	private float roundTimerTarget = 8f;

	private List<float> rnd = new List<float>();

	public static KeepCreatingObjects sharedInstance;


	private void OnEnable()
	{
		EventManager.OnStartGame += new EventManager.GamePlayDelegate(this.StarttheGame);
	}

	private void OnDisable()
	{
		EventManager.OnStartGame -= new EventManager.GamePlayDelegate(this.StarttheGame);
	}

	private void StarttheGame()
	{
		this.rnd.Add(-0.7f);
		this.rnd.Add(-0.2f);
		this.rnd.Add(0.5f);
		this.cans = (Resources.Load("Prefabs/Cans") as GameObject);
		this.sparkEffect = (Resources.Load("Prefabs/S1") as GameObject);
		this.isClicked = false;
		ObjHolders.sharedObjects.lblHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
		Constants.cons.currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
	}

	private void generateObjects()
	{
		if (!Constants.cons.isGameStarted || !Constants.cons.isNewRoundStarted || Constants.cons.isGameOver || Constants.cons.isGamePaused)
		{
			return;
		}
		int index = UnityEngine.Random.Range(0, 3);
		Vector3 position = new Vector3(2f, this.rnd[index], 0f);
		UnityEngine.Object.Instantiate<GameObject>(this.cans, position, Quaternion.identity);
		this.numberOfCansCreated++;
	}

	public void processForHighScore()
	{
		if (this.checkForHighScore(Constants.cons.score))
		{
			PlayerPrefs.SetInt("HighScore", Constants.cons.score);
			ObjHolders.sharedObjects.lblHighScore.text = Constants.cons.score.ToString();
		}
	}

	public bool checkForHighScore(int score)
	{
		return Constants.cons.currentHighScore <= score;
	}

	private void Update()
	{
		if (Constants.cons.isGamePaused || !Constants.cons.isGameStarted || Constants.cons.isGameOver)
		{
			return;
		}
		this.cansTimer += Time.deltaTime;
		int num = Mathf.Clamp(Constants.cons.currentRound, 0, 15);
		if (this.cansTimer > this.cansTimerTarget - (float)(num / 10))
		{
			this.generateObjects();
			this.cansTimer = 0f;
		}
		this.roundTimer += Time.deltaTime;
		if (this.roundTimer > this.roundTimerTarget)
		{
			Constants.cons.currentRound++;
			ObjHolders.sharedObjects.lblRound.GetComponent<Text>().text = "Round : " + Constants.cons.currentRound;
			this.roundTimer = 0f;
		}
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			position.z = 0f;
			UnityEngine.Object.Instantiate<GameObject>(this.sparkEffect, position, Quaternion.identity);
		}
	}

	public void startNewRound()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("can");
		GameObject[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			GameObject obj = array2[i];
			UnityEngine.Object.Destroy(obj);
		}
		this.cansTimer = 0f;
		this.roundTimer = 0f;
		if (this.numberOfCansCreated % 5 == 0 && this.numberOfCansCreated > 1)
		{
			//base.StartCoroutine(this.waitForCanNewRound(0.1f));
		}
		else
		{
			this.processForNewRound();
		}
	}



	public void processForNewRound()
	{
		Constants.cons.score = 0;
		ObjHolders.sharedObjects.lblScore.text = Constants.cons.score.ToString();
		Constants.cons.isNewRoundStarted = false;
		Constants.cons.currentRound++;
		ObjHolders.sharedObjects.lblRound.GetComponent<Text>().text = "Round : " + Constants.cons.currentRound;
		//base.StartCoroutine(this.setOFFtheObject(ObjHolders.sharedObjects.lblRound, 0.1f));
		ObjHolders.sharedObjects.lblHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
	}


}
