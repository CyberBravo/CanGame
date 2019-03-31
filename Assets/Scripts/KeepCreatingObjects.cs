using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class KeepCreatingObjects : MonoBehaviour {

	public GameObject cans;
	public GameObject sparkEffect;
	float[] yPosvalue = { 0.4f,0.45f,0.5f,0.55f};
	private List<float> rnd = new List<float>();

	private int numberOfCansCreated;

	private float cansTimer;

	private float cansTimerTarget = 2f;

	private float roundTimer;

	private float roundTimerTarget = 8f;
	// Use this for initialization
	bool isClicked = false;

	public Transform creatPoint;

	
		public GameObject PointEffect;
		public GameObject GroundHitEffect;
	
		int count=0;
		float rate = 7f;
	void Start () {
		Constants.cons.isGameOver = false;
		this.rnd.Add(-0.7f);
		this.rnd.Add(-0.2f);
		this.rnd.Add(0.5f);
		//InvokeRepeating ("generateObjects",5f,rate);

	}
	void generateObjects(){

		if (Constants.cons.isGameOver)
		return;
		//count++;
		//if (count % 2 == 0 && rate > 4)
			//	rate-=0.1f;
		
		SoundManager.Instance.CanFireSound ();

		int index = UnityEngine.Random.Range(0, 3);
		//Vector3 position = new Vector3(2.5f, this.rnd[index], 0f);

		Vector3 position = new Vector3(creatPoint.position.x , this.rnd[index], 0f);
		GameObject g=UnityEngine.Object.Instantiate<GameObject>(this.cans, position, Quaternion.identity);
		g.name = "Cans:" + numberOfCansCreated++;
		this.numberOfCansCreated++;

	
	}

	// Update is called once per frame
	void Update () {
		if ( Constants.cons.isGameOver )
			return;
		validateInput();
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
			//ObjHolders.sharedObjects.lblRound.GetComponent<Text>().text = "Round : " + Constants.cons.currentRound;
			this.roundTimer = 0f;
		}
		if (Input.GetMouseButtonDown(0))
		{

				Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				position.z = 0f;
				UnityEngine.Object.Instantiate<GameObject>(this.sparkEffect, position, Quaternion.identity);

				
		}
	}
		bool validInput =false;
		void validateInput()
		{
				#if UNITY_STANDALONE || UNITY_EDITOR
				//DESKTOP COMPUTERS
				if (Input.GetMouseButtonDown(0))
				{
						if (EventSystem.current.IsPointerOverGameObject())
								validInput = false;
						else
								validInput = true;
				}
				#else
				//MOBILE DEVICES
				if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
				{
				if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
				validInput = false;
				else
				validInput = true;
				}
				#endif
		}


		public void PointScoredEffect(Vector3 pos)
		{
				GameObject g=Instantiate (PointEffect,pos,Quaternion.identity) as GameObject;
				Destroy(g,5f);

		}

		public void GameEndEffect(Vector3 pos)
		{
				GameObject g=Instantiate (GroundHitEffect,pos,Quaternion.identity) as GameObject;
				Destroy(g,5f);

		}
	

}
