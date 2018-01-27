using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {


	void Start () {
	
	}
	

	void Update () {
		float angleDir = transform.eulerAngles.y * (Mathf.PI / 180.0f);
		Vector3 dir = new Vector3 (Mathf.Sin (angleDir), 0.0f, Mathf.Cos (angleDir));
		//Vector3 fwd = new Vector3 (0,0,0);
		if (Physics.Raycast (transform.position, dir, 10)) {
			Debug.Log ("ああああ");
		}
	}
}
