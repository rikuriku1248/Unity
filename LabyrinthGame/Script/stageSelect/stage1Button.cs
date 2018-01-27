using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stage1Button : MonoBehaviour{

	public void PlayStage(){
		
		SceneManager.LoadScene ("stage1");
	}
}
