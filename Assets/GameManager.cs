using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float minDistance = 0.02f;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{	

			Vector2 b = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			GameObject[] array = GameObject.FindGameObjectsWithTag("can");
			bool flag = false;
			GameObject[] array2 = array;
			float []distances = new float[array2.Length];
			print ("Array : "+array2.ToString());
			for (int i = 0; i < array2.Length; i++)
			{
				GameObject gameObject1 = array2[i];
				//print ("First: "+gameObject.transform.position);
				//print ("Second: "+b);
				//Debug.Log ("Pressed"+gameObject1.name);
				//print ("Distance: "+Vector2.Distance(gameObject1.transform.position, b));
				//print ("Min Distance: "+ minDistance);

				float dist = Vector2.Distance (gameObject1.transform.position, b);

				distances [i] = dist;
				Debug.Log ("Pressed"+gameObject1.name);

					//this.PlaySound("canPressed");


			}

			float val = distances.Min ();
			int index = Array.IndexOf (distances,val);
			if (val < minDistance) {
				array2 [index].GetComponent<CanBehavior> ().CanPressed ();
			}	
			else
			{
				Debug.Log ("missed");
				//this.PlaySound("canPressedMissed");
			}



		}
	}
}
