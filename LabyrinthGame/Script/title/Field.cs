using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
		transform.Rotate (new Vector3(0, 0.5f, 0));
	}
}
