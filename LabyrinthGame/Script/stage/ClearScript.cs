using UnityEngine;
using System.Collections;

public class ClearScript : MonoBehaviour {

	public bool isClear = false;

	void Start () {
	
	}

	void Update () {

	}

	void OnTriggerEnter(Collider other){
		isClear = true;
	}
}
