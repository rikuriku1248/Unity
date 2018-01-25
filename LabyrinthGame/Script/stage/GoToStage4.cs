using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoToStage4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoNext(){
		SceneManager.LoadScene ("stage4");
	}
}
