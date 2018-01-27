using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {

	public GameObject Field;

	void Start () {
	
	}


	void Update () {
		float diff = transform.localEulerAngles.y - Field.transform.localEulerAngles.y;

		//Eieldの回転に合わせてカメラを回転
		if(diff > 0.1f){
			transform.Rotate(new Vector3(0, 0, 0.1f));
		}else if(diff < -0.1f){
			transform.Rotate(new Vector3(0, 0, -0.1f));
		}
	}
}
