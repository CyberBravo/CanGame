using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	
	public static EventManager Instance;
	public delegate void GamePlayDelegate ();
	public static event GamePlayDelegate OnPauseGame;
	public static event GamePlayDelegate OnStartGame;
	public static void FireOnStartGame(){
		OnStartGame ();
	}
	public static void FireOnPauseGame (){
		OnPauseGame ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
