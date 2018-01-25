using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackStageSelect : MonoBehaviour {




	void Start () {
	
	}
	

	void Update () {
		
	}

	public void Back(){
		SceneManager.LoadScene ("stageSelect");
	}
}
