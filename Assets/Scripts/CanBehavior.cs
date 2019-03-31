using System;
using UnityEngine;

using System.Collections;
public class CanBehavior : MonoBehaviour
{
	public float xSpeed;

	public float ySpeed;

	public float xDecreaseSpeedFactor;

	public float yDecreaseSpeedFactor;

	public float xMinValue;

	public float yMinValue;

	public float rotationSpeed;

	public float rotationSpeedDecreaseFactor;

	public bool isStationary;

	 void Start()
	{
		int num = UnityEngine.Random.Range(0, 4);
		if (base.transform.position.y == -0.7f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 0.9f;
				this.ySpeed *= 1.5f;
				break;
			case 1:
				this.xSpeed *= 1f;
				this.ySpeed *= 1.25f;
				break;
			case 2:
				this.xSpeed *= 1.15f;
				this.ySpeed *= 1f;
				break;
			case 3:
				this.xSpeed *= 0.4f;
				this.ySpeed *= 1.1f;
				break;
			}
		}
		else if (base.transform.position.y == -0.2f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 1.1f;
				this.ySpeed *= 1.05f;
				break;
			case 1:
				this.xSpeed *= 1.2f;
				this.ySpeed *= 0.7f;
				break;
			case 2:
				this.xSpeed *= 0.7f;
				this.ySpeed *= 0.7f;
				break;
			case 3:
				this.xSpeed *= 0.5f;
				this.ySpeed *= 0.5f;
				break;
			}
		}
		else if (base.transform.position.y == 0.5f)
		{
			switch (num)
			{
			case 0:
				this.xSpeed *= 1.15f;
				this.ySpeed *= 0.3f;
				break;
			case 1:
				this.xSpeed *= 1.25f;
				this.ySpeed *= 0.3f;
				break;
			case 2:
				this.xSpeed *= 0.8f;
				this.ySpeed *= 0.2f;
				break;
			case 3:
				this.xSpeed *= 0.6f;
				this.ySpeed *= 0.1f;
				break;
			}
		}
		}
		
		
		

	bool isColliding=false;
	private void FixedUpdate()
	{
		if (Constants.cons.isGameOver || isColliding)
		{
			return;
		}
		base.transform.localPosition += new Vector3(-this.xSpeed, this.ySpeed, 0f) * Time.deltaTime;
		base.transform.Rotate(new Vector3(0f, 0f, this.rotationSpeed));
		this.rotationSpeed -= this.rotationSpeedDecreaseFactor * Time.deltaTime;
		this.rotationSpeed = Mathf.Clamp(this.rotationSpeed, 5f, 100f);
		this.xSpeed -= this.xDecreaseSpeedFactor * Time.deltaTime;
		this.ySpeed -= this.yDecreaseSpeedFactor * Time.deltaTime;
		this.xSpeed = Mathf.Clamp(this.xSpeed, this.xMinValue, 100f);
		this.ySpeed = Mathf.Clamp(this.ySpeed, this.yMinValue, 100f);
	}

	public void CanPressed()
	{
		SoundManager.Instance.Sparkle ();
		this.xSpeed = 0.85f;
		this.ySpeed = 0.75f;
		this.rotationSpeed = 25f;
	}

	public void BecomeStationary(Transform place)
	{
		this.isStationary = true;
		this.xSpeed = 0f;
		this.ySpeed = 0f;
		this.rotationSpeed = 0f;
		base.transform.rotation = Quaternion.Euler(Vector3.zero);
		base.transform.position = place.position;
		UnityEngine.Object.Destroy(base.gameObject, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Point")) {
			isColliding = true;
			SoundManager.Instance.PointsScored ();
			Destroy (this.gameObject, 5f);


			int s=0;
			if (col.gameObject.name.Contains ("10"))
				s = 10;
			else if (col.gameObject.name.Contains ("20"))
				s =  20;
			else if (col.gameObject.name .Contains("30")) 
				s = 30;

			//gameObject.GetComponent<CanBehavior>().BecomeStationary(col.transform);
			Destroy(gameObject,0.5f);
			FindObjectOfType<ClickEvents> ().SetScorePlus (s);
			Constants.cons.score += s;		
			FindObjectOfType<ClickEvents> ().SetScore (Constants.cons.score);
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			FindObjectOfType<KeepCreatingObjects> ().PointScoredEffect (transform.position);

		}	

	}
	void OnCollisionEnter2D(Collision2D col){


		//transform.Rotate (0f, 0f, Mathf.Lerp (90f,0f,0.5f));
//		if (col.gameObject.CompareTag("Point")) {
//			isColliding = true;
//			SoundManager.Instance.PointsScored ();
//			Destroy (this.gameObject, 5f);
//		
//		
//			int s=0;
//			if (col.gameObject.name.Contains ("10"))
//				s = 10;
//			else if (col.gameObject.name.Contains ("20"))
//				s =  20;
//			else if (col.gameObject.name .Contains("30")) 
//				s = 30;
//
//			//gameObject.GetComponent<CanBehavior>().BecomeStationary(col.transform);
//			Destroy(gameObject,0.5f);
//			FindObjectOfType<ClickEvents> ().SetScorePlus (s);
//			Constants.cons.score += s;		
//			FindObjectOfType<ClickEvents> ().SetScore (Constants.cons.score);
//			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
//			FindObjectOfType<KeepCreatingObjects> ().PointScoredEffect (transform.position);
//
//		}
//
//
//
////		else if(col.gameObject.name.Contains("S1")){
////
////			
////			CanPressed ();
////			//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f, (float)this.forceY));
////			//this.gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX,forceY));
////			//float randYPos = Random.Range (0,1);
////			//float randXPos = Random.Range (-1.5f, -1f);
////			//GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f, 0.2f);
////			//GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f,0.2f);
////		}
//		else 
		if (col.gameObject.name == "Ground" || col.gameObject.name == "Ground1" ) {
			if (Constants.cons.isGameOver)
				return;
			SoundManager.Instance.GameEndSound ();
			FindObjectOfType<ClickEvents>().showGameOverScreen();
			Constants.cons.isGameOver = true;

			FindObjectOfType<KeepCreatingObjects> ().GameEndEffect (transform.position);
			this.gameObject.GetComponent<BoxCollider2D>().enabled = false;	
		}

		//		this.gameObject.rigidbody2D.AddForce (new Vector2 (-2,130));




	}

}
