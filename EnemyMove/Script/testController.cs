using UnityEngine;
using System.Collections;

public class testController : MonoBehaviour {

	Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
	}
	

	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			animator.SetBool ("Spinkick",true);
		}
		if(Input.GetKey(KeyCode.A)){
			animator.SetBool ("Spinkick",false);
		}
	}
}
