using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {

	string filename = "C:\\Users\\riku\\Desktop\\Unity Projects\\Labyrinth\\Assets\\Material\\Screenshot\\stage3\\stage3_";

	float time = 0;

	int i = 0;

	void Start () {
		//string name = filename + i + ".png";
		//Debug.Log (name);
		//Application.CaptureScreenshot (filename);
	}
	

	void Update () {
		time += Time.deltaTime;
		Debug.Log (time);
		if(time % 3 == 0 && i < 20){
			string name = filename + i + ".png";

			//Application.CaptureScreenshot (name);
			i++;
		}
	}
}
