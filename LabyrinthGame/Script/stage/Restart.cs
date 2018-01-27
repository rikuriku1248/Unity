﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		int sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (sceneIndex);
	}
}