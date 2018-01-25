using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	bool stopTime = false;//時間が止まっているかどうか
	public GameObject PausePanel;
	public ClearScript clearScript;
	public Controller controller;

	void Start () {
	
	}
	

	void Update () {
		if (clearScript.isClear == false) {
			if (Input.GetKeyDown ("q")) {
				Pause ();
			}
		}
	}

	void Pause(){

		controller.MoveField = !controller.MoveField;

		if(!stopTime){
			Time.timeScale = 0;
			PausePanel.SetActive (true);
		}else{
			Time.timeScale = 1;
			PausePanel.SetActive (false);
		}

		stopTime = !stopTime;


	}
}
