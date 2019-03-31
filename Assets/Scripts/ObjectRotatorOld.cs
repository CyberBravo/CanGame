using System;
using UnityEngine;

public class ObjectRotatorOld : MonoBehaviour
{
	private bool isMouseButtonDown;

	private float rotationsPerMinute = 100f;

	private int forceY = 80;

	private bool isAbleToDetectCollision;

	private void Start()
	{
		base.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, (float)this.forceY));
		float num = (float)UnityEngine.Random.Range(0, 2);
		float num2 = UnityEngine.Random.Range(-1.5f, -1f);
		base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 1f);
		UnityEngine.Object.Destroy(base.gameObject, 3f);
		this.isAbleToDetectCollision = false;
	}

	private void FixedUpdate()
	{
		if (!this.isAbleToDetectCollision)
		{
			base.transform.Rotate(0f, 0f, (float)(6.0 * (double)this.rotationsPerMinute * (double)Time.fixedDeltaTime));
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (this.isAbleToDetectCollision)
		{
			return;
		}
		base.transform.Rotate(0f, 0f, Mathf.Lerp(90f, 0f, 0.5f));
		if (col.gameObject.name != "S1(Clone)")
		{
			this.isAbleToDetectCollision = true;
			float num = (float)UnityEngine.Random.Range(0, 1);
			float num2 = (float)UnityEngine.Random.Range(-1, -2);
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f, 0.2f);
		}
		else
		{
			base.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, (float)this.forceY));
			float num3 = (float)UnityEngine.Random.Range(0, 1);
			float num4 = UnityEngine.Random.Range(-1.5f, -1f);
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 0.2f);
		}
		string name = col.gameObject.name;
		if (name != null)
		{
			if (!(name == "Point50"))
			{
				if (!(name == "PointDown50"))
				{
					if (!(name == "Point10"))
					{
						if (name == "Point100")
						{
							Constants.cons.score += 100;
						}
					}
					else
					{
						Constants.cons.score += 10;
					}
				}
				else
				{
					Constants.cons.score += 50;
				}
			}
			else
			{
				Constants.cons.score += 50;
			}
		}
		ObjHolders.sharedObjects.lblScore.text = Constants.cons.score.ToString();
		//KeepCreatingObjects.sharedInstance.processForHighScore();
		if (col.gameObject.name == "Ground" || col.gameObject.name == "Ground1")
		{
			Constants.cons.isGameOver = true;
			//ClickEvents.sharedClickEvents.showGameOverScreen();
		}
	}

	private void PauseTheGame()
	{
		Debug.Log("Pausing the Game");
		base.GetComponent<Rigidbody2D>().isKinematic = true;
	}

	private void OnEnable()
	{
		EventManager.OnPauseGame += new EventManager.GamePlayDelegate(this.PauseTheGame);
	}

	private void OnDisable()
	{
		EventManager.OnPauseGame -= new EventManager.GamePlayDelegate(this.PauseTheGame);
	}
}
