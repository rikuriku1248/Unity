using UnityEngine;
using System.Collections;

public class OnWillRender : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnWillRenderObject()

	{

		Debug.Log(Camera.current.name);
		Debug.Log("aaaa");

	}
}
