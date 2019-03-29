	using UnityEngine;
	using System.Collections;

	public class ObjectRotator : MonoBehaviour {

		bool isMouseButtonDown;


		bool isAbleToDetectCollision;
		// Use this for initialization

		void OnCollisionEnter2D(Collision2D col){
					
			if (isAbleToDetectCollision)
				return;
			//transform.Rotate (0f, 0f, Mathf.Lerp (90f,0f,0.5f));
				if (col.gameObject.CompareTag("Point")) {
				SoundManager.Instance.PointsScored ();
				Destroy (this.gameObject, 5f);
				isAbleToDetectCollision = true;
				float randYPos = Random.Range (0,1);
				float randXPos = Random.Range (-1, -2);
	//			rigidbody2D.velocity = new Vector2(randXPos,randYPos);
				//GetComponent<Rigidbody2D>().velocity = new Vector2 (0.2f, 0.2f);
						int s=0;
						if (col.gameObject.name.Contains ("10"))
								s = 10;
						else if (col.gameObject.name.Contains ("20"))
								s =  20;
						else if (col.gameObject.name .Contains("30")) 
								s = 30;

			//gameObject.GetComponent<CanBehavior>().BecomeStationary(col.transform);
						FindObjectOfType<ClickEvents> ().SetScorePlus (s);
						Constants.cons.score += s;		
						FindObjectOfType<ClickEvents> ().SetScore (Constants.cons.score);
						this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
						FindObjectOfType<KeepCreatingObjects> ().PointScoredEffect (transform.position);
								
						}

						
			
		else if(col.gameObject.name.Contains("S1")){

						SoundManager.Instance.Sparkle ();
			//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f, (float)this.forceY));
			//this.gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX,forceY));
				//float randYPos = Random.Range (0,1);
				//float randXPos = Random.Range (-1.5f, -1f);
				//GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f, 0.2f);
				//GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f,0.2f);
			}
			else if (col.gameObject.name == "Ground" || col.gameObject.name == "Ground1" ) {
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