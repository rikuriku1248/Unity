using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	int angle = 0;
	int i = 0;
	string filename = "C:\\Users\\riku\\Desktop\\Unity Projects\\Labyrinth\\Assets\\Material\\Screenshot\\stage4\\stage4_";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(angle <= 360){
			transform.rotation = Quaternion.AngleAxis (angle, new Vector3 (0, 1, 0));
			angle += 18;
			string name = filename + i + ".png";
			i++;
			Application.CaptureScreenshot (name);
		}
	}

}
