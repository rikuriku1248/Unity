using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	float speed = 0.7f;

	public bool MoveField = true;

	void Start () {

	}

	void Update () {
		if(MoveField){
			ControllField ();
		}
	}

	void ControllField(){
		if(Input.GetKey(KeyCode.UpArrow)){
			if(transform.localEulerAngles.x <= 15 || transform.localEulerAngles.x >= 344){
				transform.Rotate(new Vector3(speed,0,0));
			}
		}else if(Input.GetKey(KeyCode.DownArrow)){
			if(transform.localEulerAngles.x <= 16 || transform.localEulerAngles.x >= 345){
				transform.Rotate(new Vector3(-speed,0,0));
			}
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			if(transform.localEulerAngles.z <= 15 || transform.localEulerAngles.z >= 344){
				transform.Rotate(new Vector3(0,0,speed));
			}
		}else if(Input.GetKey(KeyCode.RightArrow)){
			if(transform.localEulerAngles.z <= 16 || transform.localEulerAngles.z >= 345){
				transform.Rotate(new Vector3(0,0,-speed));
			}
		}
	}
}
