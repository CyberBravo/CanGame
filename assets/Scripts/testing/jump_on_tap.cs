using UnityEngine;
using System.Collections;

public class jump_on_tap : MonoBehaviour {
		public Vector3 forceValue;
		public Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
				rigid.AddForce (forceValue);
				rigid.AddTorque (forceValue.x * 2, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		void OnMouseUp(){
				rigid.AddForce (forceValue);
				rigid.AddTorque (forceValue.x * 2, ForceMode2D.Impulse);
		}
}
